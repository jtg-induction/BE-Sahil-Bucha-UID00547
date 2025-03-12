using RestaurantApp.Data;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RestaurantApp.Repositories
{
    public class OrderRepository : IOrderRepository, IDisposable
    {
        private readonly RestaurantDbContext _context;
        private bool _disposed = false;

        public OrderRepository()
        {
            _context = new RestaurantDbContext();
        }

        public IQueryable<Order> GetOrders()
        {
            Console.WriteLine("hre in repo");
            return _context.Orders.AsQueryable();
        }
        public async Task UpdateOrderStatus(int orderId, int status)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                order.Status = (Status)status;
                await _context.SaveChangesAsync();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}