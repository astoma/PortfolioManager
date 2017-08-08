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
    public class BondController : Controller
    {
        private PortfolioManagerEntity db = new PortfolioManagerEntity();

        // GET: Bond
        public ActionResult Index()
        {
            return View(db.BOND.ToList());
        }

        // GET: Bond/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOND bOND = db.BOND.Find(id);
            if (bOND == null)
            {
                return HttpNotFound();
            }
            return View(bOND);
        }

        // GET: Bond/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bond/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Issuer,Coupon,MatMonth,MatYear,SecurityId")] BOND bOND)
        {
            if (ModelState.IsValid)
            {
                db.BOND.Add(bOND);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bOND);
        }

        // GET: Bond/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOND bOND = db.BOND.Find(id);
            if (bOND == null)
            {
                return HttpNotFound();
            }
            return View(bOND);
        }

        // POST: Bond/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Issuer,Coupon,MatMonth,MatYear,SecurityId")] BOND bOND)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bOND).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bOND);
        }

        // GET: Bond/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOND bOND = db.BOND.Find(id);
            if (bOND == null)
            {
                return HttpNotFound();
            }
            return View(bOND);
        }

        // POST: Bond/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BOND bOND = db.BOND.Find(id);
            db.BOND.Remove(bOND);
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
