using System;

namespace Trading
{
    public class DealticketService
    {
        DealTicketRepository _repository;

        public Guid CreateDealTicket(DealTicket dealTicket)
        {
            return _repository.Save(dealTicket);
        }

        public void UpdateDealTicket(DealTicket dealTicket)
        {
            var currentDealTicket = _repository.GetDealTicket(dealTicket.Id);
            // No need for the all that code any more as we have methods on the object
            // currentDealTicket.Execute();
            // _repository.Save(currentDealTicket);
        }
    }
}

