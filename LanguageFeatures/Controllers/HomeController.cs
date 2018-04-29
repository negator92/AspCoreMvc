using System.Linq;
using System.Threading.Tasks;
using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        bool FilterByPrice(Product p)
            => (p?.Price ?? 0) >= 20;

        // GET
        public ViewResult Index()
        {
            var products = new[]
            {
                new {name = "Kayak", Price = 275M},
                new {name = "Lifejacket", Price = 48.95M},
                new {name = "Soccer ball", Price = 19.50M},
                new {name = "Corner flag", Price = 34.95M},
            };
            return View(products.Select(p =>
                $"{nameof(p.Name)}: {p.Name}, {nameof(p.Price)}: {p.Price}"));
        }
    }
}