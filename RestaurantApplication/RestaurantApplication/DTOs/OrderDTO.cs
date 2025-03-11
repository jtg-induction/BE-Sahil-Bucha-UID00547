using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApplication.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public string RestaurantName { get; set; }
        public DateTime OrderDate { get; set; }
        public int Status { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItemDTO> Items { get; set; }
    }

}