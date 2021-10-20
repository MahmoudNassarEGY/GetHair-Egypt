using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GetHair_Egypt.Models
{
    public class ApplicationsController : Controller
    {
        private GHEEntities db = new GHEEntities();

        // GET: Applications
        public ActionResult Index()
        {
            var applications = db.Applications.Include(a => a.Client).Include(a => a.Clinic);
            return View(applications.ToList());
        }

        // GET: Applications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // GET: Applications/Create
        public ActionResult Create(int? id)
        {
            if (Session["userName"] != null)
            {
                ViewBag.UserID = Session["ID"];
                ViewBag.CID = id;
                Clinic clinic = db.Clinics.Find(id);
                ViewBag.CImage1 = clinic.CImage1;
                ViewBag.CImage2 = clinic.CImage2;
                ViewBag.CImage3 = clinic.CImage3;
                ViewBag.CImage4 = clinic.CImage4;
                ViewBag.Address = clinic.Address;
                ViewBag.Description = clinic.Description;

                return View();
            }
            else return RedirectToAction("Login", "Clients");

        }

        // POST: Applications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppID,UserID,CID,AppDate")] Application application)
        {
            if (ModelState.IsValid)
            {
              
                db.Applications.Add(application);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = Session["ID"];
            ViewBag.CID = new SelectList(db.Clinics, "CID", "CName", application.CID);
            return View(application);
        }

        // GET: Applications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Clients, "UserID", "FName", application.UserID);
            ViewBag.CID = new SelectList(db.Clinics, "CID", "CName", application.CID);
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppID,UserID,CID,AppDate")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Entry(application).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Clients, "UserID", "FName", application.UserID);
            ViewBag.CID = new SelectList(db.Clinics, "CID", "CName", application.CID);
            return View(application);
        }

        // GET: Applications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Application application = db.Applications.Find(id);
            db.Applications.Remove(application);
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
