using System;
using Newtonsoft.Json.Linq;
using Trading;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var staticRepository = new StaticRepository();
            var dealTicketService = new DealticketService(staticRepository);

            var dealTicket = new DealTicket(10, "GBP", 10000, "kwh");

            dealTicket.Execute();

            var id = dealTicketService.CreateDealTicket(dealTicket);

            var retrievedDealTicket = staticRepository.GetDealTicket(id);

            var parsed = JObject.FromObject(retrievedDealTicket);

            foreach (var pair in parsed)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }

            Console.ReadKey();
        }
    }
}



