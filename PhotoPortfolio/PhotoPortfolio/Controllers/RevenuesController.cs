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
    public class RevenuesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Revenues
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var RevenueViewModelList = db.RegisteredUsers
                           .Join(db.Revenues,
                           c => c.UserID, r => r.RegisteredUserID,
                           (c, r) => new RevenueViewModel
                           {
                               RegisteredUser = c,
                               Total = r.Total,
                               Date = r.Date,
                               RevenueCategory = r.RevenueCategory
                           })
                           .OrderByDescending(x => x.Date)
                           .Take(5).ToList();

            ViewBag.rows = db.Revenues.Select(x => x).OrderByDescending(y => y.Date).Take(5);
            ViewBag.dates = db.Revenues.Select(x => x.Date).ToList();
            ViewBag.totals = db.Revenues.Select(x => x.Total).ToArray();
            return View(RevenueViewModelList);
        }

        public ActionResult PartialQuarterly()
        {
            ViewBag.Q1 = db.Revenues
                    .Where(x => x.Date.Month <= 3 && x.Date.Month >= 1)
                    .Select(x => x.Total)
                    .Sum(x => x);
            ViewBag.Q2 = db.Revenues
                    .Where(x => x.Date.Month <= 6 && x.Date.Month >= 4)
                    .Select(x => x.Total)
                    .Sum(x => x);
            ViewBag.Q3 = db.Revenues
                    .Where(x => x.Date.Month <= 9 && x.Date.Month >= 7)
                    .Select(x => x.Total)
                    .Sum(x => x);
            ViewBag.Q4 = db.Revenues
                    .Where(x => x.Date.Month <= 12 && x.Date.Month >= 10)
                    .Select(x => x.Total)
                    .Sum(x => x);
            return PartialView("Quarterly");
        }

        public ActionResult Quarterly()
        {

            return View();
        }
        [Authorize(Roles ="admin")]
        public ActionResult BooksPage()
        {
            var RevenueViewModelList = db.RegisteredUsers
                           .Join(db.Revenues,
                           c => c.UserID, r => r.RegisteredUserID,
                           (c, r) => new RevenueViewModel
                           {
                               RegisteredUser = c,
                               Total = r.Total,
                               Date = r.Date,
                               RevenueCategory = r.RevenueCategory
                           })
                           .OrderByDescending(x => x.Date)
                           .Take(5).ToList();

            ViewBag.rows = db.Revenues.Select(x => x).OrderByDescending(y => y.Date).Take(5);
            ViewBag.dates = db.Revenues.Select(x => x.Date).ToList();
            ViewBag.totals = db.Revenues.Select(x => x.Total).ToArray();
            return View("BooksPage");
        }

        // GET: Revenues/Details/5
        [Authorize(Roles = "admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revenue revenue = db.Revenues.Find(id);
            if (revenue == null)
            {
                return HttpNotFound();
            }
            return View(revenue);
        }
        [Authorize(Roles = "admin")]
        public ActionResult CreatePartial()
        {
            ViewBag.RegisteredUserID = new SelectList(db.RegisteredUsers, "ID", "Firstname");
            ViewBag.RevenueCategoryID = new SelectList(db.RevenueCategories, "ID", "Name");
            return PartialView("Create");
        }

        // GET: Revenues/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.RegisteredUserID = new SelectList(db.RegisteredUsers, "ID", "Firstname");
            ViewBag.RevenueCategoryID = new SelectList(db.RevenueCategories, "ID", "Name");
            return View();
        }

        // POST: Revenues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "ID, Total, Date, RegisteredUserID, RevenueCategoryID")] Revenue revenue)
        {
            if (ModelState.IsValid)
            {
                revenue.RegisteredUserID = User.Identity.GetUserId();
                //ViewBag.RevenueCategoryID = new SelectList(db.RevenueCategories, "ID", "Name", revenue.RevenueCategoryID);
                db.Revenues.Add(revenue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RevenueCategoryID = new SelectList(db.RevenueCategories, "ID", "Name", revenue.RevenueCategoryID);
            ViewBag.RegisteredUserID = new SelectList(db.RegisteredUsers, "ID", "Firstname", revenue.RegisteredUserID);
            return View(revenue);
        }

        // GET: Revenues/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revenue revenue = db.Revenues.Find(id);
            if (revenue == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegisteredUserID = new SelectList(db.RegisteredUsers, "ID", "Firstname", revenue.RegisteredUserID);
            ViewBag.RevenueCategoryID = new SelectList(db.RevenueCategories, "ID", "Name", revenue.RevenueCategoryID);
            return View(revenue);
        }

        // POST: Revenues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "ID,Total,Date,RegisteredUserID,RevenueCategoryID")] Revenue revenue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(revenue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RegisteredUserID = new SelectList(db.RegisteredUsers, "ID", "Firstname", revenue.RegisteredUserID);
            ViewBag.RevenueCategoryID = new SelectList(db.RevenueCategories, "ID", "Name", revenue.RevenueCategoryID);
            return View(revenue);
        }

        // GET: Revenues/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revenue revenue = db.Revenues.Find(id);
            if (revenue == null)
            {
                return HttpNotFound();
            }
            return View(revenue);
        }

        // POST: Revenues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Revenue revenue = db.Revenues.Find(id);
            db.Revenues.Remove(revenue);
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
