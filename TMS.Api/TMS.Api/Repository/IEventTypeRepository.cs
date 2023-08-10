using TMS.Api.Models;

namespace TMS.Api.Repository
{
    public interface IEventTypeRepository
    {
        IEnumerable<EventType> GetAll();

        Task<EventType> GetById(int id);
        
    }
}
