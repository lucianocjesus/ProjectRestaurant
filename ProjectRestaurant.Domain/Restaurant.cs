using System.Collections.Generic;

namespace ProjectRestaurant.Domain
{
    public class Restaurant
    {
        public Restaurant()
        {
            Plates = new List<Plate>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public ICollection<Plate> Plates { get; set; }
    }
}
