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
    public class CookTypeController : Controller
    {
        private FinalProjectDBEntities db = new FinalProjectDBEntities();

        // GET: CookType
        public ActionResult Index()
        {
            return View(db.CookTypes.ToList());
        }

        // GET: CookType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CookType cookType = db.CookTypes.Find(id);
            if (cookType == null)
            {
                return HttpNotFound();
            }
            return View(cookType);
        }

        // GET: CookType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CookType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CookId,CookType1")] CookType cookType)
        {
            if (ModelState.IsValid)
            {
                db.CookTypes.Add(cookType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cookType);
        }

        // GET: CookType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CookType cookType = db.CookTypes.Find(id);
            if (cookType == null)
            {
                return HttpNotFound();
            }
            return View(cookType);
        }

        // POST: CookType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CookId,CookType1")] CookType cookType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cookType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cookType);
        }

        // GET: CookType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CookType cookType = db.CookTypes.Find(id);
            if (cookType == null)
            {
                return HttpNotFound();
            }
            return View(cookType);
        }

        // POST: CookType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CookType cookType = db.CookTypes.Find(id);
            db.CookTypes.Remove(cookType);
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
