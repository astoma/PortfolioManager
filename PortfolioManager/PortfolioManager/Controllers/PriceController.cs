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
    public class PriceController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: PRICEs
        public ActionResult Index()
        {
            return View(db.PRICE.ToList());
        }

        // GET: PRICEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRICE pRICE = db.PRICE.Find(id);
            if (pRICE == null)
            {
                return HttpNotFound();
            }
            return View(pRICE);
        }

        // GET: PRICEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PRICEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SecurityId,BidPrice,OfferPrice,Date")] PRICE pRICE)
        {
            if (ModelState.IsValid)
            {
                db.PRICE.Add(pRICE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pRICE);
        }

        // GET: PRICEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRICE pRICE = db.PRICE.Find(id);
            if (pRICE == null)
            {
                return HttpNotFound();
            }
            return View(pRICE);
        }

        // POST: PRICEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SecurityId,BidPrice,OfferPrice,Date")] PRICE pRICE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRICE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pRICE);
        }

        // GET: PRICEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRICE pRICE = db.PRICE.Find(id);
            if (pRICE == null)
            {
                return HttpNotFound();
            }
            return View(pRICE);
        }

        // POST: PRICEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRICE pRICE = db.PRICE.Find(id);
            db.PRICE.Remove(pRICE);
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
