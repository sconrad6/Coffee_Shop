using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Coffee_Shop.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Coffee_Shop.Controllers
{
    public class CoffeeShopController : Controller 
    {
        List<RegisterUser> users = new List<RegisterUser>();

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
                string userJson = HttpContext.Session.GetString("UserSession");
                if (userJson != null)
                {
                    users = JsonConvert.DeserializeObject<List<RegisterUser>>(userJson);
                }
                users.Add(user);
                HttpContext.Session.SetString("UserSession", JsonConvert.SerializeObject(users));
                //return View("ListUsers", users);
                return RedirectToAction("ListUsers", user);
            }
           return View("UserForm", user);  
        }

        public IActionResult UserView(RegisterUser user)
        {
            return View(user);
        }

        public IActionResult ListUsers()
        {
            string userJson = HttpContext.Session.GetString("UserSession");
            if (userJson != null)
            {
                users = JsonConvert.DeserializeObject<List<RegisterUser>>(userJson);
            }
            return View(users);
        }
    }
}
