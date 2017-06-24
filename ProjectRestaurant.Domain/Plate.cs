namespace ProjectRestaurant.Domain
{
    public class Plate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        
    }
}
