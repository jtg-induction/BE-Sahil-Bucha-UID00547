using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApplication.Models
{
	public class Restaurant
	{
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        public User Owner { get; set; }
        public ICollection<Menu> Menus { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}