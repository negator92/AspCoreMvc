using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WorkingWithVisualStudio.Models;

namespace WorkingWithVisualStudio.Controllers
{
    public class HomeController : Controller
    {
        public SimpleRepository Repository = SimpleRepository.SharedRepository;

        public IActionResult Index()
            => View(Repository.Products
                .Where(product => product?.Price < 50));

        [HttpGet]
        public IActionResult AddProduct()
            => View(new Product());

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            Repository.AddProduct(product);
            return RedirectToAction(nameof(Index));
        }
    }
}