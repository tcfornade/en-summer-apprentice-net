﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TMS.Api.Models;

namespace TMS.Api.Repository
{
    
    public class OrderRepository : IOrderRepository
    {
        private readonly TicketManagementSystemContext _dbContext;
        
        public OrderRepository()
        {
            _dbContext = new TicketManagementSystemContext();
        }
    
        public int Add(Order @order)
        {
            throw new NotImplementedException();
        }
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = _dbContext.Orders;
            return orders;
        }

        public Order GetById(int id)
        {
            var @order = _dbContext.Orders.Where(o => o.OrderId == id).FirstOrDefault();

            return @order;
        }

        public void Update(Order @order)
        {
            throw new NotImplementedException();
        }
    }
}
