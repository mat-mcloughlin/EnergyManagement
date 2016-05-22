using System;
using Infrastructure;
using Messages;

namespace Trading
{
    public class DealTicket : Entity
    {
        public DealTicket(Guid id, Price price, Amount amount)
        {
            Id = id;
            Price = price;
            Amount = amount;
            Status = DealTicketStatus.Open;
        }

        public void Execute()
        {
            Status = DealTicketStatus.Executed;
            Events.Add(new DealTicketExecuted(Id, Price.Currency, Price.Value, Amount.Unit, Amount.Volume));
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

        public void AdjustCostings(Price price, Amount amount)
        {
            CheckDealticketIsNotExecuted();

            Price = price;
            Amount = amount;
        }

        void CheckDealticketIsNotExecuted()
        {
            if (Status != DealTicketStatus.Executed)
            {
                throw new Exception("Deal ticket cannot be modified once it has been executed");
            }
        }

        public Guid Id { get; private set; }

        public Price Price { get; private set; }

        public Amount Amount { get; private set; }


        public DealTicketStatus Status { get; private set; }
    }
}