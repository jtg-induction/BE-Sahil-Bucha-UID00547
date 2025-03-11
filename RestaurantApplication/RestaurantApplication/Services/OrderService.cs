using RestaurantApplication.DTOs;
using RestaurantApplication.Models;
using RestaurantApplication.Repositories;
using RestaurantApplication.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RestaurantApplication.Services
{
    public class OrderService: IOrderService
    {
        private readonly OrderRepository _orderRepo;
        public OrderService()
        {
            _orderRepo = new OrderRepository();
        }
        public async Task<List<OrderDTO>> GetOrders(int restaurantId, string sortBy, string username, int? status)
        {
            Console.WriteLine("here");
            var orderQuery = _orderRepo.GetOrders().Include("User").Include("Restaurant");
            Console.WriteLine("erere");
            if (!string.IsNullOrEmpty(username))
            {
                Console.WriteLine("here");
                orderQuery = orderQuery.Where(order => order.User.Name.Contains(username));
            }

            if (status.HasValue)
            {
                Console.WriteLine("here");
                orderQuery = orderQuery.Where(order => order.Status == (Status)status);
            }

            if (!string.IsNullOrEmpty(sortBy))
            {
                Console.WriteLine("here");
                switch (sortBy)
                {
                    case "date_asc":
                        orderQuery = orderQuery.OrderBy(order => order.OrderDate);
                        break;
                    case "date_dsc":
                        orderQuery = orderQuery.OrderByDescending(order => order.OrderDate);
                        break;
                    default:
                        break;
                }
            }

            return await orderQuery.Select(o => new OrderDTO
            {
                OrderId = o.OrderId,
                RestaurantName = o.Restaurant.Name,
                OrderDate = o.OrderDate,
                Status = (int)o.Status,
                TotalPrice = o.OrderItems.Sum(oi => oi.Menu.Price * oi.Quantity),
                Items = o.OrderItems.Select(oi => new OrderItemDTO
                {
                    MenuItem = oi.Menu.Name,
                    Quantity = oi.Quantity,
                    Price = oi.Menu.Price
                }).ToList()
            }).ToListAsync();
        }

        public async Task UpdateOrderStatus(int orderId, int status)
        {
            await _orderRepo.UpdateOrderStatus(orderId, status);
        }
    }
}