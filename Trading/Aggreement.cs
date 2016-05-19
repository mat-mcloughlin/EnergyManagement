using System;
using System.Collections.Generic;

namespace Trading
{
    public class Aggreement 
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public Guid CustomerId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Strategy Strategy { get; set; }

        public IList<DealTicket> DealTickets { get; set; }
    }
}
