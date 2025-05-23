

using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants
{
    internal class RestaurantsService(IRestaurantsRepository restaurantsRepository, ILogger<RestaurantsService> logger) : IRestaurantsService
    {
        public async Task<IEnumerable<RestaurantDTO?>> GetAllRestaurants()
        {
            logger.LogInformation("Getting All Restaurants");
            var restaurants = await restaurantsRepository.GetAllAsync();
            return restaurants.Select(RestaurantDTO.FromEntity) !;
        }

        public async Task<RestaurantDTO?> GetRestaurantbyId(Guid id)
        {
            logger.LogInformation($"Get Restaurant by Id: {id} ");
            var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(id);
            return RestaurantDTO.FromEntity(restaurant); 
        }
    }
}
