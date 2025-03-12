namespace RestaurantApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class AuthConfiguration : DbMigrationsConfiguration<RestaurantApp.Data.AuthDbContext>
    {
        public AuthConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations/AuthMigrations";
        }

        protected override void Seed(RestaurantApp.Data.AuthDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
