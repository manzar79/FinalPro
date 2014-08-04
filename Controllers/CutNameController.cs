using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalPro;

namespace FinalPro.Controllers
{
    public class CutNameController : Controller
    {
        private FinalProjectDBEntities db = new FinalProjectDBEntities();

        // GET: CutName
        public ActionResult Index()
        {
            var cutNames = db.CutNames.Include(c => c.Animal);
            return View(cutNames.ToList());
        }

        // GET: CutName/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CutName cutName = db.CutNames.Find(id);
            if (cutName == null)
            {
                return HttpNotFound();
            }
            return View(cutName);
        }

        // GET: CutName/Create
        public ActionResult Create()
        {
            ViewBag.AnimalId = new SelectList(db.Animals, "AnimalId", "AnimalName");
            return View();
        }

        // POST: CutName/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CutId,CutName1,AnimalId")] CutName cutName)
        {
            if (ModelState.IsValid)
            {
                db.CutNames.Add(cutName);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnimalId = new SelectList(db.Animals, "AnimalId", "AnimalName", cutName.AnimalId);
            return View(cutName);
        }

        // GET: CutName/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CutName cutName = db.CutNames.Find(id);
            if (cutName == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnimalId = new SelectList(db.Animals, "AnimalId", "AnimalName", cutName.AnimalId);
            return View(cutName);
        }

        // POST: CutName/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CutId,CutName1,AnimalId")] CutName cutName)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cutName).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnimalId = new SelectList(db.Animals, "AnimalId", "AnimalName", cutName.AnimalId);
            return View(cutName);
        }

        // GET: CutName/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CutName cutName = db.CutNames.Find(id);
            if (cutName == null)
            {
                return HttpNotFound();
            }
            return View(cutName);
        }

        // POST: CutName/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CutName cutName = db.CutNames.Find(id);
            db.CutNames.Remove(cutName);
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
