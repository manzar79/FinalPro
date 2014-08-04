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
    public class CookCutController : Controller
    {
        private FinalProjectDBEntities db = new FinalProjectDBEntities();

        // GET: CookCut
        public ActionResult Index()
        {
            var cookCuts = db.CookCuts.Include(c => c.CookType).Include(c => c.CutName);
            return View(cookCuts.ToList());
        }

        // GET: CookCut/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CookCut cookCut = db.CookCuts.Find(id);
            if (cookCut == null)
            {
                return HttpNotFound();
            }
            return View(cookCut);
        }

        // GET: CookCut/Create
        public ActionResult Create()
        {
            ViewBag.CookId = new SelectList(db.CookTypes, "CookId", "CookType1");
            ViewBag.CutId = new SelectList(db.CutNames, "CutId", "CutName1");
            return View();
        }

        // POST: CookCut/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CutId,CookId,Good_Bad,CookCutId")] CookCut cookCut)
        {
            if (ModelState.IsValid)
            {
                db.CookCuts.Add(cookCut);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CookId = new SelectList(db.CookTypes, "CookId", "CookType1", cookCut.CookId);
            ViewBag.CutId = new SelectList(db.CutNames, "CutId", "CutName1", cookCut.CutId);
            return View(cookCut);
        }

        // GET: CookCut/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CookCut cookCut = db.CookCuts.Find(id);
            if (cookCut == null)
            {
                return HttpNotFound();
            }
            ViewBag.CookId = new SelectList(db.CookTypes, "CookId", "CookType1", cookCut.CookId);
            ViewBag.CutId = new SelectList(db.CutNames, "CutId", "CutName1", cookCut.CutId);
            return View(cookCut);
        }

        // POST: CookCut/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CutId,CookId,Good_Bad,CookCutId")] CookCut cookCut)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cookCut).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CookId = new SelectList(db.CookTypes, "CookId", "CookType1", cookCut.CookId);
            ViewBag.CutId = new SelectList(db.CutNames, "CutId", "CutName1", cookCut.CutId);
            return View(cookCut);
        }

        // GET: CookCut/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CookCut cookCut = db.CookCuts.Find(id);
            if (cookCut == null)
            {
                return HttpNotFound();
            }
            return View(cookCut);
        }

        // POST: CookCut/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CookCut cookCut = db.CookCuts.Find(id);
            db.CookCuts.Remove(cookCut);
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
