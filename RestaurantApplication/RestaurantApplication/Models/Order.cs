using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantApplication.Models
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
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public DateTime OrderDate { get; set; }
        public Status Status { get; set; }
        public User User { get; set; }
        public Restaurant Restaurant { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }

}