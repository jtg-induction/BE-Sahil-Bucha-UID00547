using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApplication.DTOs
{
    public class OrderItemDTO
    {
        public string MenuItem { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

}