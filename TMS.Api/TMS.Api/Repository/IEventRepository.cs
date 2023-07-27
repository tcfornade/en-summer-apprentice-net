using TMS.Api.Models;

namespace TMS.Api.Repository
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();

        Task<Event> GetById(int id);

        Event GetByName(string name);

        int Add(Event @event);

        void Update(Event @event);

        void Delete(Event @event);

    }
}
