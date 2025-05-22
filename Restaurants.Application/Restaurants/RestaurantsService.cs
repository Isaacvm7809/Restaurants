

using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositores;

namespace Restaurants.Application.Restaurants
{
    internal class RestaurantsService(IRestaurantsRepository restaurants)
    {
        public Task<IEnumerable<Restaurant>> GetAllRestaurants()
        {
            
        }
    }
}
