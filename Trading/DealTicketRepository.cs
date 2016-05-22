using System;
using MemBus;

namespace Trading
{
    public class DealTicketRepository
    {
        private readonly IBus _bus;

        public DealTicketRepository(IBus bus)
        {
            _bus = bus;
        }

        public Guid Save(DealTicket dealTicket)
        {
            // Save the data

            // publish the events
            foreach (var @event in dealTicket.Events)
            {
                _bus.Publish(@event);
            }

            return Guid.NewGuid();
        }

        public DealTicket GetDealTicket(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}