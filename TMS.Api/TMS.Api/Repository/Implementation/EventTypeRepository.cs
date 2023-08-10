using Microsoft.Extensions.Logging;
using TMS.Api.Exceptions;
using TMS.Api.Models;

namespace TMS.Api.Repository.Implementation
{
    public class EventTypeRepository : IEventTypeRepository
    {
        private readonly TicketManagementSystemContext _dbContext;

        public EventTypeRepository()
        {
            _dbContext = new TicketManagementSystemContext();
        }
        public IEnumerable<EventType> GetAll()
        {
            var eventType = _dbContext.EventTypes;
            return eventType;
        }

        public async Task<EventType> GetById(int id)
        {
            var @eventType = _dbContext.EventTypes.Where(e => e.EventTypeId == id).FirstOrDefault();

            if (@eventType == null)
                throw new EntityNotFoundException(id, nameof(Event));

            return @eventType;
        }
    }
}
