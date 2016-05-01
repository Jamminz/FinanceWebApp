using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DashboardController : Controller
    {
        private NSDbContext db = new NSDbContext();

        // GET: Dashboard
        [Authorize]
        public ActionResult Index()
        {

            string findUser = Session["UserID"].ToString();
            ViewBag.expenseTotal = 0;
            ViewBag.incomeTotal = 0;

            var expenditureList = from o in db.Expenditures
                              where o.CreatedBy == findUser
                              select o.Amount;

            var incomeList = from o in db.Incomes
                                  where o.CreatedBy == findUser
                                  select o.Amount;


            return View();
        }
    }
}