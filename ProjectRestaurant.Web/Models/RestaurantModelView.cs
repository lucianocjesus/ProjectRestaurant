using System.ComponentModel.DataAnnotations;

namespace ProjectRestaurant.Web.Models
{
    public class RestaurantModelView
    {
        public int Id { get; set; }

        [Display(Name = "Restaurante(s)")]
        public string Name { get; set; }

        [Display(Name = "Ramo / Detalhes")]
        public string Details { get; set; }
    }
}