
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;

namespace Restaurants.API.Controllers
{

    [ApiController]
    [Route("/api/restaurants")]
    public class RestaurantsController(IRestaurantsService restaurantsService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => 
            Ok(await restaurantsService.GetAllRestaurants());           


    }
}
