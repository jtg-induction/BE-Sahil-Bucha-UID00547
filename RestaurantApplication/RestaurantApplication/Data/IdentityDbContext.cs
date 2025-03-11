using Microsoft.AspNet.Identity.EntityFramework;
using RestaurantApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantApplication.Data
{
    public class IdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDbContext() : base("DefaultConnection"){ }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public static IdentityDbContext Create()
        {
            return new IdentityDbContext();
        }
    }

}