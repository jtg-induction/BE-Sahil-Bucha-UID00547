using RestaurantApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApplication.Repositories
{
    interface IOrderRepository: IDisposable
    {
        IQueryable<Order> GetOrders();
        Task UpdateOrderStatus(int orderId, string status);
    }



}
