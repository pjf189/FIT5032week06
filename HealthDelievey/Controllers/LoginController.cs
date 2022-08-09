using HealthDelievey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthDelievey.Controllers
{
    public class LoginController : Controller
    {
        // link to database
        private Models.HealthDeliveryDBEntities HealthDeliveryDB = new HealthDeliveryDBEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //POST: login implement
        [HttpPost]
        public ActionResult Index(String username, String password)
        {
            if (String.IsNullOrEmpty(username))
            {
                ViewBag.Notice = "Username cannot be empty";
                return View();
            }
            if (String.IsNullOrEmpty(password))
            {
                ViewBag.Notice = "Password cannot be empty";
                return View();
            }
            h_admin admin = HealthDeliveryDB.h_admin.FirstOrDefault(p => p.username == username);
            if(admin == null)
            {
                ViewBag.Notice = "User does not exist";
            }else if(admin.pass != password)
            {
                ViewBag.Notice = "Wrong password";
            }
            else
            {
                return Redirect("/Home/Index");
            }
            return View();
        }
    }
}