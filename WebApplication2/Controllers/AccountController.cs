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
using Roles = WebApplication2.Models.Roles;

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
                using (NexcFinaDbContext db = new NexcFinaDbContext())
                {
                    string username = user.UserName;
                    string password = user.Password;
                    bool userValid = db.Users.Any(o => o.UserName == username && user.Password == password);
                    bool isAdmin = false;

                    if (userValid)
                    {
                        FormsAuthentication.SetAuthCookie(username, true);
                        Session["UserID"] = username;

                        var adminCheck = from o in db.Users
                            where o.UserName == username
                            select o;

                        foreach (var i in adminCheck)
                        {
                            if (i.Role == Roles.Admin)
                                isAdmin = true;
                        }

                        if (isAdmin)
                        {
                            Session["Admin"] = 1;
                        }
    
                    if (returnUrl != null) 
                            return Redirect(returnUrl);
                        else
                        {
                            return RedirectToAction("Index", "Dashboard");
                        }
                        
                    }
                    else ModelState.AddModelError("", "The user name or password does not exist");
                }

            return View();
        }


        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session["UserID"] = null;
            Session["Admin"] = null;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User usr)
        {
            using (NexcFinaDbContext db = new NexcFinaDbContext())
            {
                    if (db.Users.Any(o => o.UserName == usr.UserName))
                    {
                        ModelState.AddModelError("", "Username already exists");
                    }
                    else
                    {
                        usr.Role = Roles.User;
                        db.Users.Add(usr);
                        db.SaveChanges();

                        return RedirectToAction("Index", "Account");
                    }

                }

            return View();
        }
    }


}
