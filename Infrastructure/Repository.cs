using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using EventStore.ClientAPI.SystemData;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Infrastructure
{
    public class Repository
    {
        readonly IEventStoreConnection _cn;
        static readonly Encoding Encoding = new UTF8Encoding(false, true);
        static readonly byte[] EmptyBytes = { };

        static readonly UserCredentials UserCredentials = new UserCredentials("admin", "changeit");

        public Repository()
        {
            _cn = EventStoreConnection.Create(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1113));
            _cn.ConnectAsync().GetAwaiter().GetResult();
        }

        public async Task<T> Get<T>(Guid id)
          where T : Aggregate
        {
            var serializer = new JsonSerializer();
            var slice = await _cn.ReadStreamEventsForwardAsync(id.ToString(), 0, 100, true, UserCredentials);
            var aggregate = (T)Activator.CreateInstance(typeof(T), true);
            do
            {
                foreach (var re in slice.Events)
                {

                    using (var r = new JsonTextReader(new StreamReader(new MemoryStream(re.Event.Data))))
                    {
                        aggregate.Apply(serializer.Deserialize(r, Type.GetType(re.Event.EventType, true)));
                        aggregate.Version = re.Event.EventNumber;
                    }
                }
                slice = await _cn.ReadStreamEventsForwardAsync(id.ToString(), slice.NextEventNumber, 100, true, UserCredentials);

            } while (!slice.IsEndOfStream);

            aggregate.Id = id;
            return aggregate;
        }

        public Task Save(Aggregate aggregate)
        {
            var serializer = new JsonSerializer();

            var originalVersion = aggregate.Version - aggregate.Events.Count;
            var expectedVersion = originalVersion == 0 ? ExpectedVersion.NoStream : originalVersion - 1;
            var eventData = aggregate.Events.Select(x => new EventData(Guid.NewGuid(), x.GetType().FullName, true, Encoding.GetBytes(JObject.FromObject(x, serializer).ToString(Formatting.None)), EmptyBytes));
            return _cn.AppendToStreamAsync(aggregate.Id.ToString(), expectedVersion, eventData);
        }
    }
}