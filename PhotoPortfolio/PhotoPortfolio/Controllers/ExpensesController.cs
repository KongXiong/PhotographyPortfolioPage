using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhotoPortfolio.Models;
using Microsoft.AspNet.Identity;

namespace PhotoPortfolio.Controllers
{
    public class ExpensesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Expenses
        public ActionResult Index()
        {
            ViewBag.rows = db.Expenses.Select(x => x).OrderByDescending(y => y.Date).Take(5);
            ViewBag.dates = db.Expenses.OrderBy(x => x.Date).Select(y => y.Date).Take(30);
            ViewBag.intArray = db.Expenses.OrderBy(y => y.Date).Select(a => a.Total).ToArray();
            ViewBag.totals = db.Expenses.Select(x => x).OrderByDescending(y => y.Date).Take(30);
            var expenses = db.Expenses.Include(e => e.ExpenseCategory);
            return View(expenses.ToList());
        }

        public ActionResult PartialQuarterly()
        {
            if ((db.Expenses
                .Where(x => x.Date.Month <= 3 && x.Date.Month >= 1)
                .Select(x => x.Total)
                .Sum(x => x)) != 0)
            {
                ViewBag.Q1 = db.Expenses
                    .Where(x => x.Date.Month <= 3 && x.Date.Month >= 1)
                    .Select(x => x.Total)
                    .Sum(x => x);
            }
            else
            {
                ViewBag.Q1 = 0;
            };

            var q2 = db.Expenses
                .Where(x => x.Date.Month <= 6 && x.Date.Month >= 4)
                .Select(x => x.Total)
                .Sum(x => x);

            if ((q2 != 0))
            {
                ViewBag.Q2 = db.Expenses
                .Where(x => x.Date.Month <= 6 && x.Date.Month >= 4)
                .Select(x => x.Total)
                .Sum(x => x);
            }
            else
            {
                ViewBag.Q2 = 0;
            };

            var q3 = db.Expenses
            .Where(x => x.Date.Month <= 9 && x.Date.Month >= 7)
            .Select(x => x.Total)
            .Sum(x => x);

            if (q3 != 0)
            {
                ViewBag.Q3 = db.Expenses
                .Where(x => x.Date.Month <= 9 && x.Date.Month >= 7)
                .Select(x => x.Total)
                .Sum(x => x);
            }
            else
            {
                ViewBag.Q3 = 0;
            };

            var q4 = db.Expenses
                .Where(x => x.Date.Month <= 12 && x.Date.Month >= 10)
                .Select(x => x.Total)
                .Sum(x => x);


            ViewBag.Q4 = db.Expenses
            .Where(x => x.Date.Month <= 12 && x.Date.Month >= 10)
            .Select(x => x.Total)
            .Sum(x => x);


            return PartialView("Quarterly");
        }

        // GET: Expenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // GET: Expenses/Create

        public ActionResult CreatePartial()
        {
            ViewBag.ExpenseCategoryID = new SelectList(db.ExpenseCategories, "ID", "Name");
            //if (ModelState.IsValid)
            //{
            //    Expense expense = new Expense();
            //    expense.RegisteredUserID = User.Identity.GetUserId();
            //    ViewBag.ExpenseCategoryID = new SelectList(db.ExpenseCategories, "ID", "Name", expense.ExpenseCategoryID);
            //    db.Expenses.Add(expense);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //    //return View("Index");
            //}
            return PartialView("Create");
        }

        public ActionResult Create()
        {
            ViewBag.ExpenseCategoryID = new SelectList(db.ExpenseCategories, "ID", "Name");
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Payee,Total,Date,ExpenseCategoryID")] Expense expense)
        {
            ViewBag.ExpenseCategoryID = new SelectList(db.ExpenseCategories, "ID", "Name", expense.ExpenseCategoryID);
            if (ModelState.IsValid)
            {
                expense.RegisteredUserID = User.Identity.GetUserId();
                ViewBag.ExpenseCategoryID = new SelectList(db.ExpenseCategories, "ID", "Name", expense.ExpenseCategoryID);
                db.Expenses.Add(expense);
                db.SaveChanges();
                return RedirectToAction("Index");
                //return View("Index");
            }

            return View("Index");
        }

        // GET: Expenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExpenseCategoryID = new SelectList(db.ExpenseCategories, "ID", "Name", expense.ExpenseCategoryID);
            return View(expense);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Payee,Total,Date,ExpenseCategoryID")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expense).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExpenseCategoryID = new SelectList(db.ExpenseCategories, "ID", "Name", expense.ExpenseCategoryID);
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expense expense = db.Expenses.Find(id);
            db.Expenses.Remove(expense);
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
