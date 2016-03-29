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
            var registeredUsers = db.RegisteredUsers.Include(r => r.User);
            return View(registeredUsers.ToList());
        }

        // GET: RegisteredUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredUser registeredUser = db.RegisteredUsers.Find(id);
            if (registeredUser == null)
            {
                return HttpNotFound();
            }
            return View(registeredUser);
        }


        public ActionResult Landing()
        {
            return View();
        }

        public ActionResult ClientName(int ID)
        {

            return View();
        }

        public ActionResult AdminClientControls()
        {

            ViewBag.RegisteredUserID = new SelectList(db.RegisteredUsers, "ID", "Firstname");

            return View();
        }

        // GET: RegisteredUsers/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            //ViewBag.UserID = new SelectList(db.ApplicationUsers, "Id", "Email");
            return View();
        }

        // POST: RegisteredUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "ID,Firstname,Lastname,Address,City,State,ZipCode,UserID")] RegisteredUser registeredUser)
        {
            if (ModelState.IsValid)
            {
                //registeredUser.UserID = User.Identity.GetUserId();
                db.RegisteredUsers.Add(registeredUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.UserID = new SelectList(db.ApplicationUsers, "Id", "Email", registeredUser.UserID);
            return View(registeredUser);
        }

        // GET: RegisteredUsers/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredUser registeredUser = db.RegisteredUsers.Find(id);
            if (registeredUser == null)
            {
                return HttpNotFound();
            }
            //ViewBag.UserID = new SelectList(db.ApplicationUsers, "Id", "Email", registeredUser.UserID);
            return View(registeredUser);
        }

        // POST: RegisteredUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "ID,Firstname,Lastname,Address,City,State,ZipCode,UserID")] RegisteredUser registeredUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registeredUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.UserID = new SelectList(db.ApplicationUsers, "Id", "Email", registeredUser.UserID);
            return View(registeredUser);
        }

        // GET: RegisteredUsers/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredUser registeredUser = db.RegisteredUsers.Find(id);
            if (registeredUser == null)
            {
                return HttpNotFound();
            }
            return View(registeredUser);
        }

        // POST: RegisteredUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegisteredUser registeredUser = db.RegisteredUsers.Find(id);
            db.RegisteredUsers.Remove(registeredUser);
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
