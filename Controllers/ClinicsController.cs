using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GetHair_Egypt.Models;
using System.IO;

namespace GetHair_Egypt.Controllers
{
    public class ClinicsController : Controller
    {
        private GHEEntities db = new GHEEntities();

        // GET: Clinics
        public ActionResult Index()
        {
            if (Session["userName"] != null)
                return View(db.Clinics.ToList());
           else
                return RedirectToAction("Login"); 
          //Uncomment apove for security
        }

        // GET: Clinics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinic clinic = db.Clinics.Find(id);
            if (clinic == null)
            {
                return HttpNotFound();
            }
            return View(clinic);
        }

        // GET: Clinics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clinics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CName,Email,CUrl,Password,Address, Description")] Clinic clinic, HttpPostedFileBase imgFile1, HttpPostedFileBase imgFile2, HttpPostedFileBase imgFile3, HttpPostedFileBase imgFile4)
        {
            if (ModelState.IsValid)
            {
                string path1 = "";
                string path2 = "";
                string path3 = "";
                string path4 = "";

               try {

                if (imgFile1 != null)
                {
                    path1 = "~/Images/" + Path.GetFileName(imgFile1.FileName);

                    imgFile1.SaveAs(Server.MapPath(path1));
                }

                if (imgFile2 != null)
                {
                    path2 = "~/Images/" + Path.GetFileName(imgFile2.FileName);

                    imgFile2.SaveAs(Server.MapPath(path2));
                }

                if (imgFile3 != null)
                {
                    path3 = "~/Images/" + Path.GetFileName(imgFile3.FileName);

                    imgFile3.SaveAs(Server.MapPath(path3));
                }

                if (imgFile4 != null)
                {
                    path4 = "~/Images/" + Path.GetFileName(imgFile4.FileName);

                    imgFile4.SaveAs(Server.MapPath(path4));
                }
            }
            catch (Exception)
               {
                ViewBag.FileStatus = "Error while image uploading."; ;
               }

                clinic.CImage1 = path1;
                clinic.CImage2 = path2;
                clinic.CImage3 = path3;
                clinic.CImage4 = path4;

                db.Clinics.Add(clinic);
                db.SaveChanges();
                return RedirectToAction("");
            }

            return View(clinic);
        }

        // GET: Clinics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinic clinic = db.Clinics.Find(id);
            if (clinic == null)
            {
                return HttpNotFound();
            }
            return View(clinic);
        }

        // POST: Clinics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Clinic clinic, HttpPostedFileBase imgFile1, HttpPostedFileBase imgFile2, HttpPostedFileBase imgFile3, HttpPostedFileBase imgFile4)
        {
            if (ModelState.IsValid)
            {
                string path1 = "";
                string path2 = "";
                string path3 = "";
                string path4 = "";

                try
                {

                    if (imgFile1 != null)
                    {
                        path1 = "~/Images/" + Path.GetFileName(imgFile1.FileName);

                        imgFile1.SaveAs(Server.MapPath(path1));
                    }

                    if (imgFile2 != null)
                    {
                        path2 = "~/Images/" + Path.GetFileName(imgFile2.FileName);

                        imgFile2.SaveAs(Server.MapPath(path2));
                    }

                    if (imgFile3 != null)
                    {
                        path3 = "~/Images/" + Path.GetFileName(imgFile3.FileName);

                        imgFile3.SaveAs(Server.MapPath(path3));
                    }

                    if (imgFile4 != null)
                    {
                        path4 = "~/Images/" + Path.GetFileName(imgFile4.FileName);

                        imgFile4.SaveAs(Server.MapPath(path4));
                    }
                }
                catch (Exception)
                {
                    ViewBag.FileStatus = "Error while image uploading."; ;
                }

                clinic.CImage1 = path1;
                clinic.CImage2 = path2;
                clinic.CImage3 = path3;
                clinic.CImage4 = path4;
               var before = db.Clinics.AsNoTracking().Where(x => x.CID == clinic.CID).ToList().FirstOrDefault();
                clinic.Password = before.Password;
                clinic.confEmail = before.confEmail;
                clinic.confPassword = before.confPassword;
                db.Entry(clinic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clinic);
        }

        // GET: Clinics/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinic clinic = db.Clinics.Find(id);
            if (clinic == null)
            {
                return HttpNotFound();
            }
            return View(clinic);
        }

        // POST: Clinics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Clinic clinic = db.Clinics.Find(id);
            db.Clinics.Remove(clinic);
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

        public ActionResult Login()
        {
            Session["userName"] = null;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include ="Email,Password")]Clinic clinic)
        {
            var rec = db.Clinics.Where(x => x.Email == clinic.Email && x.Password == clinic.Password).FirstOrDefault();
            if (rec != null)
            {
                Session["userName"] = rec.CName; 
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.error = "Invalid Email or Password";
                return View(clinic);
            }
        }

        public ActionResult HomePage()
        {
            var recs = db.Clinics.ToList();
            if (Session["userName"] != null)
                return View(recs);
            else return RedirectToAction("Login", "Clients");


        }
    }
}
