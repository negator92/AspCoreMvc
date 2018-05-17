﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WorkingWithVisualStudio.Models;

namespace WorkingWithVisualStudio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
            => View(SimpleRepository.SharedRepository.Products
                .Where(product => product?.Price < 50));
    }
}