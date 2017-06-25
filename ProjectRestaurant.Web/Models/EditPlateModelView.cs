using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ProjectRestaurant.Web.Models
{
    public class EditPlateModelView
    {
        public int Id { get; set; }

        [Display(Name = "Restaurante")]
        [Required(ErrorMessage = "Campo Restaurante é obrigatório")]
        public int RestaurantId { get; set; }

        [Display(Name = "Nome do prato")]
        [Required(ErrorMessage = "Campo Nome do prato é obrigatório")]
        public string NamePlate { get; set; }

        [Display(Name = "Ingredientes")]
        [Required(ErrorMessage = "Campo Nome dos Ingredientes é obrigatório")]
        public string Ingredients { get; set; }

        [Display(Name = "Restaurante")]
        public string NameRestaurant { get; set; }

        public SelectList RestaurantOptions { get; set; }
    }
}