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
        public IActionResult ListUsers()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult RegisterUserList()
        //{
        //    string userJson = HttpContext.Session.GetString("UserSession");
        //    if (userJson != null)
        //    {
        //        users = JsonConvert.DeserializeObject<List<RegisterUser>>(userJson);
        //    }
        //    return View("ListUsers", users);
        //}

        [HttpPost]
        // this will save the user's information in a cookie
        public IActionResult SaveUser(RegisterUser user)
        {
            CookieOptions option = new CookieOptions();
            Response.Cookies.Append("UserName", user.UserName, option);
            Response.Cookies.Append("FirstName", user.FirstName, option);
            Response.Cookies.Append("LastName", user.LastName, option);
            Response.Cookies.Append("Email", user.Email, option);
            Response.Cookies.Append("Age", user.Age.ToString(), option);

            return RedirectToAction("SaveUser", user);
        }

    }
}
