using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Coffee_Shop.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Coffee_Shop.Controllers
{
    public class HomeController : Controller
    {
        List<RegisterUser> users = new List<RegisterUser>();

        public IActionResult ListUsers()
        {
            return View(users);
        }

        public IActionResult AddUser(RegisterUser user)
        {
            string userJson = HttpContext.Session.GetString("UserSession");
            if (userJson != null)
            {
                users = JsonConvert.DeserializeObject<List<RegisterUser>>(userJson);
            }
            users.Add(user);
            return View("ListUsers", user);
        }

        public IActionResult RegisterUserList()
        {
            string userJson = HttpContext.Session.GetString("UserSession");
            if (userJson != null)
            {
                users = JsonConvert.DeserializeObject<List<RegisterUser>>(userJson);
            }
            return View("ListUsers", users);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
