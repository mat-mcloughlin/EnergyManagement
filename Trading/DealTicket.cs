using System;

namespace Trading
{
    public class DealTicket
    {
        public DealTicket(Guid id, decimal price, string currency, int amount, string unit)
        {
            if (price <= 0 || string.IsNullOrWhiteSpace(currency))
            {
                throw new Exception("Deal ticket must have a price");
            }

            if (amount <= 0 || string.IsNullOrWhiteSpace(unit))
            {
                throw new Exception("Deal ticket must have an amount");
            }

            Id = id;
            Price = price;
            Currency = currency;
            Amount = amount;
            Unit = unit;
            Status = DealTicketStatus.Open;
        }

        public Guid Id { get; set; }

        public decimal Price { get; set; }

        public string Currency { get; set; }

        public int Amount { get; set; }

        public string Unit { get; set; }

        public DealTicketStatus Status { get; set; }
    }
}