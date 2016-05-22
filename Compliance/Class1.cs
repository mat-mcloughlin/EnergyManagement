using Infrastructure;
using Messages;

namespace Compliance
{
    public class DealTicketExecutedHandler : IHandler<DealTicketExecuted>
    {
        public void Handle(DealTicketExecuted message)
        {
            // do somethign with it here
        }
    }
}
