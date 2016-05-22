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

        }
    }
}

