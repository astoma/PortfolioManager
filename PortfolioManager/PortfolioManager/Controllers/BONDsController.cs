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
    public class BONDsController : Controller
    {
        private PortfolioManagerEntities db = new PortfolioManagerEntities();

        // GET: BONDs
        public ActionResult Index()
        {
            return View(db.BOND.ToList());
        }

        // GET: BONDs/Details/5
        public ActionResult Details(string id)
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

        // GET: BONDs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BONDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BondIssuer,Coupon,MaturityMonth,MaturityYear")] BOND bOND)
        {
            if (ModelState.IsValid)
            {
                db.BOND.Add(bOND);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bOND);
        }

        // GET: BONDs/Edit/5
        public ActionResult Edit(string id)
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

        // POST: BONDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BondIssuer,Coupon,MaturityMonth,MaturityYear")] BOND bOND)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bOND).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bOND);
        }

        // GET: BONDs/Delete/5
        public ActionResult Delete(string id)
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

        // POST: BONDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
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
