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
    [Authorize(Roles = "Administrator")]
    public class PrimalCutController : Controller
    {
        private FinalProjectDBEntities1 db = new FinalProjectDBEntities1();

        // GET: PrimalCut
        public ActionResult Index()
        {
            var primalCuts = db.PrimalCuts.Include(p => p.Animal);
            return View(primalCuts.ToList());
        }

        // GET: PrimalCut/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrimalCut primalCut = db.PrimalCuts.Find(id);
            if (primalCut == null)
            {
                return HttpNotFound();
            }
            return View(primalCut);
        }

        // GET: PrimalCut/Create
        public ActionResult Create()
        {
            ViewBag.AnimalId = new SelectList(db.Animals, "AnimalId", "AnimalName");
            return View();
        }

        // POST: PrimalCut/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrimalCutId,PrimalCutName,AnimalId")] PrimalCut primalCut)
        {
            if (ModelState.IsValid)
            {
                db.PrimalCuts.Add(primalCut);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnimalId = new SelectList(db.Animals, "AnimalId", "AnimalName", primalCut.AnimalId);
            return View(primalCut);
        }

        // GET: PrimalCut/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrimalCut primalCut = db.PrimalCuts.Find(id);
            if (primalCut == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnimalId = new SelectList(db.Animals, "AnimalId", "AnimalName", primalCut.AnimalId);
            return View(primalCut);
        }

        // POST: PrimalCut/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrimalCutId,PrimalCutName,AnimalId")] PrimalCut primalCut)
        {
            if (ModelState.IsValid)
            {
                db.Entry(primalCut).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnimalId = new SelectList(db.Animals, "AnimalId", "AnimalName", primalCut.AnimalId);
            return View(primalCut);
        }

        // GET: PrimalCut/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrimalCut primalCut = db.PrimalCuts.Find(id);
            if (primalCut == null)
            {
                return HttpNotFound();
            }
            return View(primalCut);
        }

        // POST: PrimalCut/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrimalCut primalCut = db.PrimalCuts.Find(id);
            db.PrimalCuts.Remove(primalCut);
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
