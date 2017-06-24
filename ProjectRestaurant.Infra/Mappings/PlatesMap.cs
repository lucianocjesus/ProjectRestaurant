using System.Data.Entity.ModelConfiguration;
using ProjectRestaurant.Domain;

namespace ProjectRestaurant.Infra.Mappings
{
    public class PlatesMap : EntityTypeConfiguration<Plate>
    {
        public PlatesMap()
        {
            ToTable("Pratos");

            HasKey(x => x.Id);
            Property(x => x.Name).HasMaxLength(60).IsRequired();
            Property(x => x.Ingredients).HasMaxLength(400).IsRequired();
        }
    }
}
