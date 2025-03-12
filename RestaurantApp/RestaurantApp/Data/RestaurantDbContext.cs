using Microsoft.AspNet.Identity.EntityFramework;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantApp.Data
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext() : base("DatabaseConnection") { }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Menu> Menus { get; set; }
    }
}
