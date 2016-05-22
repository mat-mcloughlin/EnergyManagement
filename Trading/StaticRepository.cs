using System;
using System.Collections.Generic;
using System.Linq;

namespace Trading
{
    public class StaticRepository
    {
        static readonly List<DealTicket> DealTickets = new List<DealTicket>();

        public Guid Save(DealTicket dealTicket)
        {
            DealTickets.Add(dealTicket);
            return dealTicket.Id;
        }

        public DealTicket GetDealTicket(Guid id)
        {
            return DealTickets.FirstOrDefault(d => d.Id == id);
        }
    }
}
