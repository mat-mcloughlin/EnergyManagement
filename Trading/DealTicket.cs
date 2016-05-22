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
        }

        public void Execute()
        {
            Status = DealTicketStatus.Executed;
        }

        public void Reopen()
        {
            CheckDealticketIsNotExecuted();

            Status = DealTicketStatus.Open;
        }

        public void Cancel()
        {
            CheckDealticketIsNotExecuted();

            Status = DealTicketStatus.Cancelled;
        }

        public void AdjustCostings(decimal price, string currency, int amount, string unit)
        {
            CheckDealticketIsNotExecuted();

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

        void CheckDealticketIsNotExecuted()
        {
            if (Status != DealTicketStatus.Executed)
            {
                throw new Exception("Deal ticket cannot be modified once it has been executed");
            }
        }

        public Guid Id { get; private set; }

        public decimal Price { get; private set; }

        public string Currency { get; private set; }

        public int Amount { get; private set; }

        public string Unit { get; private set; }

        public DealTicketStatus Status { get; private set; }
    }
}