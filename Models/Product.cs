namespace Product.Models
{
    public class Productt
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image {  get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public int Stock { get; set; }
        public int Rating { get; set; }
        public bool IsActive { get; set; }
    }
}
