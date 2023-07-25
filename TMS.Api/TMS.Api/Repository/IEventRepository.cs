using TMS.Api.Models;

namespace TMS.Api.Repository
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();

        Event GetById(int id);

        int Add(Event @event);

        void Update(Event @event);

        int Delete(int id);
    }
}
