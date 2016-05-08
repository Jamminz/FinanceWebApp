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
        private LastDbContext db = new LastDbContext();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user, string returnUrl)
        {
             
                    string username = user.UserName;
                    string password = user.Password;
                    //Check if there is a user with the details provided
                    bool userValid = db.Users.Any(o => o.UserName == username && user.Password == o.Password);
                    bool isAdmin = false;

                    if (userValid)
                    {
                        //if user is found, authenticate
                        FormsAuthentication.SetAuthCookie(username, true);
                        Session["UserID"] = username;

                        //retrieve current user from db
                        var adminCheck = from o in db.Users
                            where o.UserName == username
                            select o;


                        // check if retrieved user has the role of admin
                        foreach (var i in adminCheck)
                        {
                            if (i.Role == Roles.Admin)
                                isAdmin = true;
                        }

                        // set session variable to not null in order to display admin panel shortcut. for SHORTCUT ONLY, roles handled by role provider
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
                    //error message if user not found
                    else ModelState.AddModelError("", "The user name or password does not exist");

            return View();
        }


        public ActionResult LogOff()
        {
            // delete auth cookie, set session variables to null
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
                    // check if username already exists on database
                    if (db.Users.Any(o => o.UserName == usr.UserName))
                    {
                        ModelState.AddModelError("", "Username already exists");
                    }
                    else
                    {
                        // sets default role as user and adds user to the database
                        usr.Role = Roles.User;
                        db.Users.Add(usr);
                        db.SaveChanges();

                        return RedirectToAction("Index", "Account");
                    }

            return View();
        }
    }


}
