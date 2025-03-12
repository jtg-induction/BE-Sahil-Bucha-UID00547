using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace RestaurantApp.Models
{
	public class Restaurant
	{
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string OwnerId { get; set; }
        public ICollection<Menu> Menus { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}