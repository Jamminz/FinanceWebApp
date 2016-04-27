using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                string[] names = (from c in db.Users
                                  select c.UserName).ToArray();

                for (int i = 0; i < names.Length; i++)
                {
                    if (names[i] == user.UserName)
                    {
                        ModelState.AddModelError("", "Username already exists");
                    }
                    else
                    {
                        db.Users.Add(user);
                        db.SaveChanges();

                        return RedirectToAction("Index", "Home");
                    }

                }

            }

            return View();
        }
    }
}