using Infrastructure;
using Messages;

namespace Trading
{
    class ExecuteDealTicketHandler : IHandler<ExecuteDealTicket>
    {
        readonly DealTicketRepository _repository;

        public ExecuteDealTicketHandler(DealTicketRepository repository)
        {
            _repository = repository;
        }

        public void Handle(ExecuteDealTicket message)
        {
            var dealTicket = _repository.GetDealTicket(message.DealTicketId);
            dealTicket.Execute();
            _repository.Save(dealTicket);
        }
    }
}
