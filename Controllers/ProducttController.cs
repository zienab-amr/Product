using Microsoft.AspNetCore.Mvc;
using Product.Services;

namespace Product.Controllers
{
    public class ProducttController : Controller
    {
        private readonly ProductService _productService;
        public ProducttController(ProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View(_productService.GetAll());
        }
        public IActionResult Details(int Id)
        {
            var product = _productService.GetDetailsProduct(Id);

            if (product == null)
                return NotFound();

            return View(product);
        }
    }
}
