

using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories
{
    public interface IRestaurantsRepository
    {
        Task<IEnumerable<Restaurant>> GetAllAsync();
        Task<Restaurant?> GetRestaurantByIdAsync(Guid id);

        //Task AddRestaurantAsync(Restaurant restaurant, CancellationToken cancellationToken = default);
        //Task UpdateRestaurantAsync(Restaurant restaurant, CancellationToken cancellationToken = default);
        //Task DeleteRestaurantAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
