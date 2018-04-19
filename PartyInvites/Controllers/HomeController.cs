using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ViewBag.Greeting = DateTime.Now.Hour < 12 ?
                "Good morning" :
                "Good afternoon";
            return View("MyView");
        }

        [HttpGet]
        public ViewResult RsvpForm()
            => View();

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse((guestResponse));
                return View("Thanks", guestResponse);
            }
            else
                return View();
        }

        public ViewResult ListResponses()
            => View(Repository.Responses.Where(response => response.WillAttend == true));
    }
}