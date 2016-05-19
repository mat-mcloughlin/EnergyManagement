using System;

namespace Trading
{
    public class DealTicket
    {
        public Guid Id { get; set; }

        public decimal Price { get; set; }

        public string Currency { get; set; }

        public int Amount { get; set; }

        public string Unit { get; set; }

        public DealTicketStatus Status { get; set; }
    }
}