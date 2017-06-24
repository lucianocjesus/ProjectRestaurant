using System.Data.Entity.ModelConfiguration;
using ProjectRestaurant.Domain;

namespace ProjectRestaurant.Infra.Mappings
{
    public class RestaurantsMap : EntityTypeConfiguration<Restaurant>
    {
        public RestaurantsMap()
        {
            ToTable("Restaurantes");
            Property(x => x.Name).HasMaxLength(60).IsRequired();

            HasMany(x => x.Plates).WithRequired(x => x.Restaurant);

        }
    }
}
