using Infrastructure;

namespace Trading
{
    {
        readonly DealTicketRepository _repository;

        public ExecuteDealTicketHandler(DealTicketRepository repository)
        {
            _repository = repository;
        }

        {
            var dealTicket = _repository.GetDealTicket(message.DealTicketId);
            dealTicket.Execute();
            _repository.Save(dealTicket);
        }
    }
}
