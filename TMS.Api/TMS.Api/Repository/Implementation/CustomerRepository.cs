using TMS.Api.Models;

namespace TMS.Api.Repository.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly TicketManagementSystemContext _dbContext;

        public CustomerRepository()
        {
            _dbContext = new TicketManagementSystemContext();
        }

        /* public async Task<IEnumerable<Customer>> GetAllAsync()
        {
           var customers = await _dbContext.Customers.ToListAsync();
            return customers;

         }*/

        public IEnumerable<Customer> GetAll()
        {
            var customers = _dbContext.Customers.ToList();
            return customers;
        }

       /* public async Task<Customer> GetByIdAsync(int id)
        {
            var customer = await _dbContext.Customers.Where(e => e.CustomerID == id).FirstOrDefaultAsync();
            return customer;
        }*/

        /*public Customer GetById(int id)
        {
            var customer = _dbContext.Customers.Where(e => e.Customerid == id).FirstOrDefault();
            return customer;
        }*/
    }
}
