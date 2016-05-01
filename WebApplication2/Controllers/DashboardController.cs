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
        private NexFinDbContext db = new NexFinDbContext();
        
        //Bonus,
        //Refund,
        //Overtime,
        //Liquidation

        // GET: Dashboard
        [Authorize]
        public ActionResult Index()
        {
            string findUser = Session["UserID"].ToString();

            /*************************************************************************************************/

            ViewBag.salary = 0;

            var salary = from o in db.Users
                             where o.UserName == findUser
                             select o.Salary;

            foreach (var i in salary)
            {
                ViewBag.salary += i;
            }


            /*************************************************************************************************/

            ViewBag.entertainmentTotal = 0;

            string findCat = "Entertainment";

            var entertainment = from o in db.Expenditures
                                where o.CreatedBy == findUser && o.Category.ToString() == findCat
                                select o.Amount;

            foreach (var i in entertainment)
            {
                ViewBag.entertainmentTotal += i;
            }

            /*************************************************************************************************/

            findCat = "Education";

            ViewBag.educationTotal = 0;

            var education = from o in db.Expenditures
                                where o.CreatedBy == findUser && o.Category.ToString() == findCat
                                select o.Amount;
            foreach (var i in education)
            {
                ViewBag.educationTotal += i;
            }

            /*************************************************************************************************/

            findCat = "Food";

            ViewBag.foodTotal = 0;

            var food = from o in db.Expenditures
                            where o.CreatedBy == findUser && o.Category.ToString() == findCat
                            select o.Amount;
            foreach (var i in food)
            {
                ViewBag.foodTotal += i;
            }

            /*************************************************************************************************/

            findCat = "Health";

            ViewBag.healthTotal = 0;

            var health = from o in db.Expenditures
                       where o.CreatedBy == findUser && o.Category.ToString() == findCat
                       select o.Amount;
            foreach (var i in health)
            {
                ViewBag.healthTotal += i;
            }

            /*************************************************************************************************/

            findCat = "Utility";

            ViewBag.utilityTotal = 0;

            var utility = from o in db.Expenditures
                         where o.CreatedBy == findUser && o.Category.ToString() == findCat
                         select o.Amount;
            foreach (var i in utility)
            {
                ViewBag.utilityTotal += i;
            }

            /*************************************************************************************************/

            findCat = "Bonus";

            ViewBag.bonusTotal = 0;

            var bonus = from o in db.Incomes
                            where o.CreatedBy == findUser && o.Category.ToString() == findCat
                            select o.Amount;
            foreach (var i in bonus)
            {
                ViewBag.bonusTotal += i;
            }

            /*************************************************************************************************/

            findCat = "Liquidation";

            ViewBag.liquidationTotal = 0;

            var liquidation = from o in db.Incomes
                        where o.CreatedBy == findUser && o.Category.ToString() == findCat
                        select o.Amount;
            foreach (var i in liquidation)
            {
                ViewBag.liquidationTotal += i;
            }

            /*************************************************************************************************/

            findCat = "Refund";

            ViewBag.refundTotal = 0;

            var refund = from o in db.Incomes
                            where o.CreatedBy == findUser && o.Category.ToString() == findCat
                            select o.Amount;
            foreach (var i in refund)
            {
                ViewBag.refundTotal += i;
            }

            /*************************************************************************************************/

            findCat = "Overtime";

            ViewBag.overtimeTotal = 0;

            var overtime = from o in db.Incomes
                         where o.CreatedBy == findUser && o.Category.ToString() == findCat
                         select o.Amount;
            foreach (var i in overtime)
            {
                ViewBag.overtimeTotal += i;
            }

            /*************************************************************************************************/


            return View();
        }
    }
}