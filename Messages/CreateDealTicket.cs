using System;

namespace Messages
{
    public class CreateDealTicket
    {
        public Guid DealTicketId { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public string Unit { get; set; }
        public int Volume { get; set; }
    }
}