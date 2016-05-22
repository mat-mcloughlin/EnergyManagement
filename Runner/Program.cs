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

            var dealTicket = new DealTicket
            {
                Amount = 10000,
                Currency = "GBP",
                Price = 10,
                Status = DealTicketStatus.Open,
                Unit = "kwh"
            };

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



