namespace RestaurantApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class AppConfiguration : DbMigrationsConfiguration<RestaurantApp.Data.RestaurantDbContext>
    {
        public AppConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations/AppMigrations";
        }

        protected override void Seed(RestaurantApp.Data.RestaurantDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            try
            {
                //context.Restaurants.AddOrUpdate(restaurant => restaurant.RestaurantId,
                //    new Restaurant() { Name = "Indian Restaurant", Address = "New Delhi", UserId = 1 }
                //);

                //context.Menus.AddOrUpdate(menu => menu.MenuId,
                //    new Menu() { RestaurantId = 1, Name = "Spring Roll", Price = 250 },
                //    new Menu() { RestaurantId = 1, Name = "Paneer Tikka", Price = 300 }
                //);

                //context.Orders.AddOrUpdate(order => order.OrderId,
                //    new Order() { RestaurantId = 1, UserId = 1, OrderDate = DateTime.Now, Status = (Status)1 }
                //);

                //context.OrderItems.AddOrUpdate(item => item.OrderItemId,
                //    new OrderItem() { OrderId = 5, MenuId = 3, Quantity = 2 },
                //    new OrderItem() { OrderId = 5, MenuId = 4, Quantity = 1 }
                //);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error is :", e);
            }
        }
    }
}
