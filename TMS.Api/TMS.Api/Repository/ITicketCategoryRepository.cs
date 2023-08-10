using TMS.Api.Models;

namespace TMS.Api.Repository
{
    public interface ITicketCategoryRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        IEnumerable<Customer> GetAll();
        Task<Customer> GetByIdAsync(int id);
        Customer GetById(int id);
    }
}
