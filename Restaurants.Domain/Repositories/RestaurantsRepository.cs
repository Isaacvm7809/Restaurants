

using Restaurants.Domain.Entities;


namespace Restaurants.Domain.Repositories
{
    public class RestaurantsRepository(RestaurantDbContext context) : IRestaurantsRepository
    {
        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            var restaurants = await context.Restaurants.ToListAsync();
            return restaurants;
        }
    }
}
