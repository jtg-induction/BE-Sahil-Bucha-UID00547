using RestaurantApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Services
{
    interface IOrderService
    {
        Task<List<OrderDTO>> GetOrders(int restaurantId, string sortBy, string username, int? status);
        Task UpdateOrderStatus(int orderId, int status);
    }
}
