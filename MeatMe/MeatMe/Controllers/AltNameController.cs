using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeatMe.Models;
using MeatMe.CustomAttributes;

namespace MeatMe.Controllers
{
    [BasicAuthAttribute]
    public class AltNameController : Controller
    {
        private FinalProjectDBEntities1 db = new FinalProjectDBEntities1();

        // GET: AltName
        public ActionResult Index()
        {
            var altNames = db.AltNames.Include(a => a.CutName);
            return View(altNames.ToList());
        }

        // GET: AltName/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AltName altName = db.AltNames.Find(id);
            if (altName == null)
            {
                return HttpNotFound();
            }
            return View(altName);
        }

        // GET: AltName/Create
        public ActionResult Create()
        {
            ViewBag.CutId = new SelectList(db.CutNames, "CutId", "CutName1");
            return View();
        }

        // POST: AltName/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AltNameId,CutId,AltName1")] AltName altName)
        {
            if (ModelState.IsValid)
            {
                db.AltNames.Add(altName);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CutId = new SelectList(db.CutNames, "CutId", "CutName1", altName.CutId);
            return View(altName);
        }

        // GET: AltName/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AltName altName = db.AltNames.Find(id);
            if (altName == null)
            {
                return HttpNotFound();
            }
            ViewBag.CutId = new SelectList(db.CutNames, "CutId", "CutName1", altName.CutId);
            return View(altName);
        }

        // POST: AltName/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AltNameId,CutId,AltName1")] AltName altName)
        {
            if (ModelState.IsValid)
            {
                db.Entry(altName).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CutId = new SelectList(db.CutNames, "CutId", "CutName1", altName.CutId);
            return View(altName);
        }

        // GET: AltName/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AltName altName = db.AltNames.Find(id);
            if (altName == null)
            {
                return HttpNotFound();
            }
            return View(altName);
        }

        // POST: AltName/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AltName altName = db.AltNames.Find(id);
            db.AltNames.Remove(altName);
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
