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
    public class RegisteredUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RegisteredUsers
        public ActionResult Index()
        {
            return View(db.RegisteredUsers.ToList());
        }

        public ActionResult Landing()
        {
            return View();
        }

        // GET: RegisteredUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredUser RegisteredUser = db.RegisteredUsers.Find(id);
            if (RegisteredUser == null)
            {
                return HttpNotFound();
            }
            return View(RegisteredUser);
        }

        // GET: RegisteredUsers/Create
        public ActionResult CreatePartial()
        {
            return PartialView("Create");
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: RegisteredUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Firstname,Lastname,Address,City,State,ZipCode,Email,RegisteredUserID")] RegisteredUser RegisteredUser)
        {
            if (ModelState.IsValid)
            {
                RegisteredUser.RegisteredUserID = User.Identity.GetUserId();
                //ViewBag.ExpenseCategoryID = new SelectList(db.ExpenseCategories, "ID", "Name", expense.ExpenseCategoryID);
                db.RegisteredUsers.Add(RegisteredUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(RegisteredUser);
        }

        // GET: RegisteredUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredUser RegisteredUser = db.RegisteredUsers.Find(id);
            if (RegisteredUser == null)
            {
                return HttpNotFound();
            }
            return View(RegisteredUser);
        }

        // POST: RegisteredUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Firstname,Lastname,Address,City,State,ZipCode,Email,RegisteredUserID")] RegisteredUser RegisteredUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(RegisteredUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(RegisteredUser);
        }

        // GET: RegisteredUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredUser RegisteredUser = db.RegisteredUsers.Find(id);
            if (RegisteredUser == null)
            {
                return HttpNotFound();
            }
            return View(RegisteredUser);
        }

        // POST: RegisteredUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegisteredUser RegisteredUser = db.RegisteredUsers.Find(id);
            db.RegisteredUsers.Remove(RegisteredUser);
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
