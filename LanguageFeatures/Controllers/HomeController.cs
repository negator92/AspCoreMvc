using System;
using System.Linq;
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
            => View(Product.GetProducts().Select(p => p?.Name));
    }
}