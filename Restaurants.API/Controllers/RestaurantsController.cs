
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;

namespace Restaurants.API.Controllers
{

    [ApiController]
    [Route("/api/restaurants")]
    public class RestaurantsController(IRestaurantsService restaurantsService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await restaurantsService.GetAllRestaurants();
            return (restaurants == null) ?
                NotFound() :
                Ok(restaurants);

        }
        


        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId([FromRoute]Guid id ) 
        { 
            var restaurant = await restaurantsService.GetRestaurantbyId(id);   
            return (restaurant == null) ?
                NotFound(): Ok(restaurant);  
        }
    



    }
}
