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

        public void Execute()
        {
            Status = DealTicketStatus.Executed;
        }

        public void Reopen()
        {
            if (Status != DealTicketStatus.Executed)
            {
                throw new Exception("Deal ticket cannot be modified once it has been executed");
            }
            
            Status = DealTicketStatus.Open;
        }

        public void Cancel()
        {
            if (Status != DealTicketStatus.Executed)
            {
                throw new Exception("Deal ticket cannot be modified once it has been executed");
            }

            Status = DealTicketStatus.Cancelled;
        }

        public void AdjustCostings(decimal price, string currency, int amount, string unit)
        {
            if (Status != DealTicketStatus.Executed)
            {
                throw new Exception("Deal ticket cannot be modified once it has been executed");
            }

            if (price <= 0 || string.IsNullOrWhiteSpace(currency))
            {
                throw new Exception("Deal ticket must have a price");
            }

            if (amount <= 0 || string.IsNullOrWhiteSpace(unit))
            {
                throw new Exception("Deal ticket must have an amount");
            }

            Price = price;
            Currency = currency;
            Amount = amount;
            Unit = unit;
        }

        public Guid Id { get; set; }

        public decimal Price { get; set; }

        public string Currency { get; set; }

        public int Amount { get; set; }

        public string Unit { get; set; }

        public DealTicketStatus Status { get; set; }
    }
}