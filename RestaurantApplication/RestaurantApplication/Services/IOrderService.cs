using RestaurantApplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApplication.Services
{
    interface IOrderService
    {
        Task<List<OrderDTO>> GetOrders(int restaurantId, string sortBy, string username, string status);
        Task UpdateOrderStatus(int orderId, int status);
    }
}
