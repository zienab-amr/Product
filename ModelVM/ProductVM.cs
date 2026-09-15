namespace Product.ModelVM
{
    public class ProductVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile Image { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public int Stock { get; set; }
        public int Rating { get; set; }
        public bool IsActive { get; set; }
    }
}
