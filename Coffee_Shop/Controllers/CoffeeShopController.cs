using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Coffee_Shop.Models;

namespace Coffee_Shop.Controllers
{
    public class CoffeeShopController : Controller 
    {
        public IActionResult Index(RegisterUser user)
        {
            return View(user);
        }

        // Get information from our user
        [HttpGet]
        public IActionResult UserForm()
        {
            return View(new RegisterUser());
        }

        // sending user to RegisterUser action
        [HttpPost] 
        public IActionResult UserForm(RegisterUser user)
        {
            if (ModelState.IsValid)
            {
                 return RedirectToAction("Index", user);
            }
           return View("UserForm", user);  
        }

        public IActionResult UserView(RegisterUser user)
        {
            return View(user);
        }
    }
}
