using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DashboardController : Controller
    {
        private LastDbContext db = new LastDbContext();


        // function for determing which query to use to get data for the graph
        public IQueryable<decimal?> GetInfo(string findUser, string findCat)
        {
                switch (findCat.ToLower())
                {
                    case "entertainment":
                    case "education":
                    case "food":
                    case "health":
                    case "utility":

                        var returnExpense = from o in db.Expenditures
                                            where o.CreatedBy == findUser && o.Category.ToString() == findCat
                                            select o.Amount;
                        return (returnExpense);

                    case "bonus":
                    case "liquidation":
                    case "refund":
                    case "overtime":

                        var returnIncome = from o in db.Incomes
                                           where o.CreatedBy == findUser && o.Category.ToString() == findCat
                                           select o.Amount;
                        return (returnIncome);

                    default:

                        var salary = from o in db.Users
                                     where o.UserName == findUser
                                     select o.Salary;
                        return (salary);

                }

        }

        // GET: Dashboard
        [Authorize]
        public ActionResult Index()
        {

            //each section calls the above function and then sets a ViewBag value to the sum of each category of expense/income

           string findUser = Session["UserID"].ToString();

            /*************************************************************************************************/

            ViewBag.salary = 0;

            var salary = GetInfo(findUser, "salary");

            foreach (var i in salary)
            {
                ViewBag.salary += i;
            }


            /*************************************************************************************************/

            ViewBag.entertainmentTotal = 0;

            var entertainment = GetInfo(findUser, "entertainment");

            foreach (var i in entertainment)
            {
                ViewBag.entertainmentTotal += i;
            }

            /*************************************************************************************************/

            ViewBag.educationTotal = 0;

            var education = GetInfo(findUser, "education");
            foreach (var i in education)
            {
                ViewBag.educationTotal += i;
            }

            /*************************************************************************************************/

            ViewBag.foodTotal = 0;

            var food = GetInfo(findUser, "food");
            foreach (var i in food)
            {
                ViewBag.foodTotal += i;
            }

            /*************************************************************************************************/

            ViewBag.healthTotal = 0;

            var health = GetInfo(findUser, "health");
            foreach (var i in health)
            {
                ViewBag.healthTotal += i;
            }

            /*************************************************************************************************/

            ViewBag.utilityTotal = 0;

            var utility = GetInfo(findUser, "utility");
            foreach (var i in utility)
            {
                ViewBag.utilityTotal += i;
            }

            /*************************************************************************************************/

            ViewBag.bonusTotal = 0;

            var bonus = GetInfo(findUser, "bonus");
            foreach (var i in bonus)
            {
                ViewBag.bonusTotal += i;
            }

            /*************************************************************************************************/

            ViewBag.liquidationTotal = 0;

            var liquidation = GetInfo(findUser, "liquidation");
            foreach (var i in liquidation)
            {
                ViewBag.liquidationTotal += i;
            }

            /*************************************************************************************************/

            ViewBag.refundTotal = 0;

            var refund = GetInfo(findUser, "refund");
            foreach (var i in refund)
            {
                ViewBag.refundTotal += i;
            }

            /*************************************************************************************************/

            ViewBag.overtimeTotal = 0;

            var overtime = GetInfo(findUser, "overtime");
            foreach (var i in overtime)
            {
                ViewBag.overtimeTotal += i;
            }

            /*************************************************************************************************/

            // sums remaining salary

            ViewBag.remainingSalary = ViewBag.salary - ViewBag.entertainmentTotal - ViewBag.educationTotal -
                                      ViewBag.foodTotal -
                                      ViewBag.healthTotal - ViewBag.utilityTotal + ViewBag.bonusTotal +
                                      ViewBag.liquidationTotal + ViewBag.refundTotal + ViewBag.overtimeTotal;

            /*************************************************************************************************/


            return View();
        }
    }
}