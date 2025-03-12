using Microsoft.AspNet.Identity.EntityFramework;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApp.Data
{
    public class AuthDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuthDbContext() : base("DatabaseConnection") { }
        public static AuthDbContext Create() => new AuthDbContext();
    }
}