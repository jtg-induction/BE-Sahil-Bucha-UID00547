using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApp.DTOs
{
	public class OrderItemDTO
	{
        public string MenuItem { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}