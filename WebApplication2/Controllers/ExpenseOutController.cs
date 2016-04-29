using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ExpenseOutController : Controller
    {
        private FinalDbContext db = new FinalDbContext();

        // GET: ExpenseOut
        public ActionResult Index()
        {
            return View(db.Outbound.ToList());
        }

        // GET: ExpenseOut/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseOut expenseOut = db.Outbound.Find(id);
            if (expenseOut == null)
            {
                return HttpNotFound();
            }
            return View(expenseOut);
        }

        // GET: ExpenseOut/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExpenseOut/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExpenseOutId,Description,Amount,CreatedBy")] ExpenseOut expenseOut)
        {
            if (ModelState.IsValid)
            {
                db.Outbound.Add(expenseOut);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expenseOut);
        }

        // GET: ExpenseOut/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseOut expenseOut = db.Outbound.Find(id);
            if (expenseOut == null)
            {
                return HttpNotFound();
            }
            return View(expenseOut);
        }

        // POST: ExpenseOut/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExpenseOutId,Description,Amount,CreatedBy")] ExpenseOut expenseOut)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expenseOut).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseOut);
        }

        // GET: ExpenseOut/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseOut expenseOut = db.Outbound.Find(id);
            if (expenseOut == null)
            {
                return HttpNotFound();
            }
            return View(expenseOut);
        }

        // POST: ExpenseOut/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExpenseOut expenseOut = db.Outbound.Find(id);
            db.Outbound.Remove(expenseOut);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
