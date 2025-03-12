using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models
{
    public enum Status
    {
        Received,
        Processing,
        Dispatched,
        Delivered,
        Cancelled
    }
    public class Order
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int RestaurantId { get; set; }
        public DateTime OrderDate { get; set; }
        public Status Status { get; set; }
        public Restaurant Restaurant { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}