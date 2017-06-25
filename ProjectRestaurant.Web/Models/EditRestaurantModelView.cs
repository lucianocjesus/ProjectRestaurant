using System.ComponentModel.DataAnnotations;

namespace ProjectRestaurant.Web.Models
{
    public class EditRestaurantModelView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Nome do Restaurante é obrigatório")]
        [Display(Name = "Nome do Restaurante")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo Detalhes é obrigadório")]
        [Display(Name = "Ramo / Detalhes")]
        public string Details { get; set; }
    }
}