using Infrastructure;
using Messages;

namespace Trading
{
    class CreateDealTicketHandler : IHandler<CreateDealTicket>
    {
        readonly DealTicketRepository _repository;

        public CreateDealTicketHandler(DealTicketRepository repository)
        {
            _repository = repository;
        }

        public void Handle(CreateDealTicket message)
        {
            var dealTicket = new DealTicket(
                message.DealTicketId, 
                new Price(message.Price, message.Currency), 
                new Amount(message.Volume, message.Unit));

            _repository.Save(dealTicket);
        }
    }
}
