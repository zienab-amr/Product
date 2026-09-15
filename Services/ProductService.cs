using Product.Data;
using Product.Models;
using Product.ModelVM;

namespace Product.Services
{
    public class ProductService
    {
        private readonly ProductDbContext _db;
        public ProductService(ProductDbContext db)
        {
            _db = db;
        }

        public List<Productt> GetAll() => _db.Products.ToList();

        public Productt? GetDetailsProduct(int Id) => _db.Products.SingleOrDefault(p => p.Id == Id);
    }

}
