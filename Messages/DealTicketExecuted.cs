using System;

namespace Messages
{
    public class DealTicketExecuted
    {
        public DealTicketExecuted(Guid dealTicketId, string currency, decimal value, string unit, int volume)
        {
            DealTicketId = dealTicketId;
            Currency = currency;
            Value = value;
            Unit = unit;
            Volume = volume;
        }

        public Guid DealTicketId { get; set; }

        public string Currency { get; set; }

        public decimal Value { get; set; }

        public string Unit { get; set; }

        public int Volume { get; set; }
    }
}