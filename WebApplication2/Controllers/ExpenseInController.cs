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
    public class ExpenseInController : Controller
    {
        private FinalDbContext db = new FinalDbContext();

        // GET: ExpenseIn
        public ActionResult Index()
        {
            return View(db.Inbound.ToList());
        }

        // GET: ExpenseIn/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseIn expenseIn = db.Inbound.Find(id);
            if (expenseIn == null)
            {
                return HttpNotFound();
            }
            return View(expenseIn);
        }

        // GET: ExpenseIn/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExpenseIn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExpenseInId,Description,Amount,CreatedBy")] ExpenseIn expenseIn)
        {
            if (ModelState.IsValid)
            {
                db.Inbound.Add(expenseIn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expenseIn);
        }

        // GET: ExpenseIn/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseIn expenseIn = db.Inbound.Find(id);
            if (expenseIn == null)
            {
                return HttpNotFound();
            }
            return View(expenseIn);
        }

        // POST: ExpenseIn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExpenseInId,Description,Amount,CreatedBy")] ExpenseIn expenseIn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expenseIn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseIn);
        }

        // GET: ExpenseIn/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseIn expenseIn = db.Inbound.Find(id);
            if (expenseIn == null)
            {
                return HttpNotFound();
            }
            return View(expenseIn);
        }

        // POST: ExpenseIn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExpenseIn expenseIn = db.Inbound.Find(id);
            db.Inbound.Remove(expenseIn);
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
