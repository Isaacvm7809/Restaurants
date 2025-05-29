

using Microsoft.EntityFrameworkCore;

using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories
{
    internal class RestaurantsRepository(RestaurantDbContext context) : IRestaurantsRepository
    {
        public async Task<IEnumerable<Restaurant>> GetAllAsync() => 
            await context.Restaurants
                .Include(r => r.Dishes)
                .ToListAsync();

        public async Task<Restaurant?> GetRestaurantByIdAsync(Guid id) =>
            await context.Restaurants
                .Where(r => r.Id == id) 
                .Include(d=> d.Dishes)
                .FirstOrDefaultAsync()   ;

    }
}
