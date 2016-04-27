using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    string username = user.UserName;
                    string password = user.Password;
                    bool userValid = db.Users.Any(o => o.UserName == username && user.Password == password);

                    if (userValid)
                    {
                        FormsAuthentication.SetAuthCookie(username, false);
                        Session["UserID"] = username;

                        if (returnUrl != null) 
                            return Redirect(returnUrl);
                        else
                        {
                            return RedirectToAction("Index", "Dashboard");
                        }
                        
                    }
                    else ModelState.AddModelError("", "The user name or password does not exist");
                }
            }

            return View();
        }


        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session["UserID"] = null;

            return RedirectToAction("Index", "Home");
        }


    }
}