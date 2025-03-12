using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Repositories
{
    interface IOrderRepository
    {
        IQueryable<Order> GetOrders();
        Task UpdateOrderStatus(int orderId, int status);
    }
}
