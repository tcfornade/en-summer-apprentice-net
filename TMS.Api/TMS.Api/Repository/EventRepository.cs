using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TMS.Api.Exceptions;
using TMS.Api.Models;

namespace TMS.Api.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly TicketManagementSystemContext _dbContext;

        public EventRepository()
        {
            _dbContext = new TicketManagementSystemContext();
        }

        public int Add(Event @event)
        {
            throw new NotImplementedException();
        }

        public void Delete(Event @event)
        {
            _dbContext.Remove(@event);
            _dbContext.SaveChanges();
        }
        public IEnumerable<Event> GetAll()
        {
            var events = _dbContext.Events;

            return events;
        }

        public async Task<Event> GetById(int id)
        {
            var @event = await _dbContext.Events.Where(e => e.EventId == id).FirstOrDefaultAsync();

            if (@event == null)
                throw new EntityNotFoundException(id, nameof(Event));

            return @event;
        }



        public Event GetByName(string name) 
        {
            // var @event = _dbContext.Events.FirstOrDefault(e => e.EventName.Equals(name));
            var @event = _dbContext.Events.Where(e => e.EventName.Equals(name)).FirstOrDefault();
            return @event;
        }

        public void Update(Event @event)
        {
            _dbContext.Entry(@event).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }

}
