using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PortfolioManager.Models;

namespace PortfolioManager.Controllers
{
    public class FutureController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: Future
        public ActionResult Index()
        {
            return View(db.FUTURE.ToList());
        }

        // GET: Future/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FUTURE fUTURE = db.FUTURE.Find(id);
            if (fUTURE == null)
            {
                return HttpNotFound();
            }
            return View(fUTURE);
        }

        // GET: Future/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Future/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FutureId,Exchange,Symbol,Name,MatDate,Quantity,ClrAlias,SecurityId")] FUTURE fUTURE)
        {
            if (ModelState.IsValid)
            {
                db.FUTURE.Add(fUTURE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fUTURE);
        }

        // GET: Future/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FUTURE fUTURE = db.FUTURE.Find(id);
            if (fUTURE == null)
            {
                return HttpNotFound();
            }
            return View(fUTURE);
        }

        // POST: Future/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FutureId,Exchange,Symbol,Name,MatDate,Quantity,ClrAlias,SecurityId")] FUTURE fUTURE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fUTURE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fUTURE);
        }

        // GET: Future/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FUTURE fUTURE = db.FUTURE.Find(id);
            if (fUTURE == null)
            {
                return HttpNotFound();
            }
            return View(fUTURE);
        }

        // POST: Future/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FUTURE fUTURE = db.FUTURE.Find(id);
            db.FUTURE.Remove(fUTURE);
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
