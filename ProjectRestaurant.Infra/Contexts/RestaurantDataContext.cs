using System.Data.Entity;
using ProjectRestaurant.Domain;
using ProjectRestaurant.Infra.Mappings;

namespace ProjectRestaurant.Infra.Contexts
{
    public class RestaurantDataContext : DbContext
    {
        public RestaurantDataContext() : base("RestaurantConnectionString")
        {
            
        }

        public DbSet<Plate> Plates { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PlatesMap());
            modelBuilder.Configurations.Add(new RestaurantsMap());
        }
    }
}
