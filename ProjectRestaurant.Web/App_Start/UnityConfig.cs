using System.Web.Mvc;
using Microsoft.Practices.Unity;
using ProjectRestaurant.Domain.Repositories.Contracts;
using Unity.Mvc5;
using ProjectRestaurant.Infra.Contexts;
using ProjectRestaurant.Infra.Repositories;

namespace ProjectRestaurant.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<RestaurantDataContext, RestaurantDataContext>();
            container.RegisterType<IPlateRepository, PlatesRepository>();
            container.RegisterType<IRestaurantRepository, RestaurantsRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}