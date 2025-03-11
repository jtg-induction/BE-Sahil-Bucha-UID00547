using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace RestaurantApplication.Models
{
    public enum Role
    {
        User,
        Owner
    }
	public class User
    {            
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}