using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TMS.Api.Models;

namespace TMS.Api.Repository.Implementation
{

    public class OrderRepository : IOrderRepository
    {
        private readonly TicketManagementSystemContext _dbContext;

        public OrderRepository()
        {
            _dbContext = new TicketManagementSystemContext();
        }

        public async Task AddAsync(Order order)
        {
            _dbContext.Add(order);
            await _dbContext.SaveChangesAsync();

        }
        public void Add(Order order)
        {
            _dbContext.Add(order);
            _dbContext.SaveChanges();
        }

        public void Delete(Order @order)
        {
            _dbContext.Remove(@order);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = _dbContext.Orders;
            return orders;
        }

        public async Task<Order> GetById(int id)
        {
            var @order = await _dbContext.Orders.Where(x => x.OrderId == id).FirstOrDefaultAsync();

            return @order;
        }

        public void Update(Order @order)
        {
            _dbContext.Entry(@order).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }


    }
}
