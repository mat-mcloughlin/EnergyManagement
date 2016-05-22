using System;

namespace Trading
{
    public class DealticketService
    {
        readonly StaticRepository _repository;

        public DealticketService(StaticRepository repository)
        {
            _repository = repository;
        }

        public Guid CreateDealTicket(DealTicket dealTicket)
        {


            return _repository.Save(dealTicket);
        }

        public void UpdateDealTicket(DealTicket dealTicket)
        {
            var currentDealTicket = _repository.GetDealTicket(dealTicket.Id);

            // Cannot modify a deal ticket once its been executed.
            if (currentDealTicket.Status == DealTicketStatus.Executed)
            {
                throw new Exception("Deal ticket cannot be modified once it has been executed");
            }

            if (currentDealTicket.Status == DealTicketStatus.Cancelled && dealTicket.Status == DealTicketStatus.Open)
            {
                currentDealTicket.Status = dealTicket.Status;
            }
            else
            {
                if (dealTicket.Price <= 0 || string.IsNullOrWhiteSpace(dealTicket.Currency))
                {
                    throw new Exception("Deal ticket must have a price");
                }

                if (dealTicket.Amount <= 0 || string.IsNullOrWhiteSpace(dealTicket.Unit))
                {
                    throw new Exception("Deal ticket must have an amount");
                }

                currentDealTicket.Status = dealTicket.Status;
                currentDealTicket.Amount = dealTicket.Amount;
                currentDealTicket.Currency = dealTicket.Currency;
                currentDealTicket.Unit = dealTicket.Unit;
                currentDealTicket.Price = dealTicket.Price;
            }
        }
    }
}

