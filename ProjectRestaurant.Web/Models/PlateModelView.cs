using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectRestaurant.Web.Models
{
    public class PlateModelView
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }

        [Display(Name = "Nome do prato")]
        public string NamePlate { get; set; }

        [Display(Name = "Restaurante")]
        public string NameRestaurant { get; set; }

        [Display(Name = "Ingredientes")]
        public string Ingredients { get; set; }
    }
}