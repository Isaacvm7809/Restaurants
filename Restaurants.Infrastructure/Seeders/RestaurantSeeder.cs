
using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders
{
    internal class RestaurantSeeder(RestaurantDbContext context) : IRestaurantSeeder
    {
        public async Task Seed()
        {
            if (await context.Database.CanConnectAsync())
            {
                if (!context.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    context.Restaurants.AddRange(restaurants);
                    await context.SaveChangesAsync();
                }
            }



            // Seed the database with initial data
            // This is where you would add your restaurant data to the context
            // For example:
            // context.Restaurants.Add(new Restaurant { Name = "Restaurant 1", Location = "Location 1" });
            // context.SaveChanges();
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            List<Restaurant> restaurants = [
                new Restaurant
                {
                    Id = Guid.NewGuid(),
                    Name = "Restaurant 1",
                    Description = "Description 1",
                    HasDelivery = true,
                    Address = new Address
                    {
                        Street = "Street 1",
                        City = "City 1",
                        PostalCode = "PostalCode 1",
                    },
                    Category = "French",
                },
                new Restaurant
                {
                    Id = Guid.NewGuid(),
                    Name = "Restaurant 2",
                    Description = "Description 2",
                    HasDelivery = false,
                    Address = new Address
                    {
                        Street = "Street 2",
                        City = "City 2",
                        PostalCode = "PostalCode 2",
                    },
                    Category = "Italian",
                    Dishes = new List<Dish>
                    {
                        new Dish
                        {
                            Name = "Dish 1",
                            Description = "Description 1",
                            Price = 10.99m,
                        },
                        new Dish
                        {
                            Name = "Dish 2",
                            Description = "Description 2",
                            Price = 12.99m,
                        }
                    }

                }
            ];
            return restaurants;
        }
    }
}
