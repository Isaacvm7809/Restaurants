﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Restaurants.Domain.Repositories;

using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.Seeders;

namespace Restaurants.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<RestaurantDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("RestaurantDb")) );
            var connectionString  = configuration.GetConnectionString("RestaurantDb");
                services.AddDbContext<RestaurantDbContext>(options => options.UseSqlServer(connectionString));


            services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
            //services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
            services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
        }
    }
}
