using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runnner
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new Repository();

            var guid = Guid.NewGuid();

            var aggregate = new TestAggregate(guid);
            aggregate.Do("what the hell?");
            repository.Save(aggregate).GetAwaiter().GetResult();

            var newAgg = repository.Get<TestAggregate>(guid).GetAwaiter().GetResult();
            newAgg.Do("Something else");
            repository.Save(newAgg).GetAwaiter().GetResult();


        }
    }
}
