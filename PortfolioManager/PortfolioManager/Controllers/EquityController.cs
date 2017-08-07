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
    public class EquityController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: Equity
        public ActionResult Index()
        {
            var eQUITY = db.EQUITY.Include(e => e.INDUSTRY).Include(e => e.SECTOR);
            return View(eQUITY.ToList());
        }

        // GET: Equity/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EQUITY eQUITY = db.EQUITY.Find(id);
            if (eQUITY == null)
            {
                return HttpNotFound();
            }
            return View(eQUITY);
        }

        // GET: Equity/Create
        public ActionResult Create()
        {
            ViewBag.IndustryId = new SelectList(db.INDUSTRY, "IndustryId", "IndustryName");
            ViewBag.SectorId = new SelectList(db.SECTOR, "SectorId", "SectorName");
            return View();
        }

        // POST: Equity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Symbol,Name,IPOyear,SectorId,IndustryId,Quote,SecurityId")] EQUITY eQUITY)
        {
            if (ModelState.IsValid)
            {
                db.EQUITY.Add(eQUITY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IndustryId = new SelectList(db.INDUSTRY, "IndustryId", "IndustryName", eQUITY.IndustryId);
            ViewBag.SectorId = new SelectList(db.SECTOR, "SectorId", "SectorName", eQUITY.SectorId);
            return View(eQUITY);
        }

        // GET: Equity/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EQUITY eQUITY = db.EQUITY.Find(id);
            if (eQUITY == null)
            {
                return HttpNotFound();
            }
            ViewBag.IndustryId = new SelectList(db.INDUSTRY, "IndustryId", "IndustryName", eQUITY.IndustryId);
            ViewBag.SectorId = new SelectList(db.SECTOR, "SectorId", "SectorName", eQUITY.SectorId);
            return View(eQUITY);
        }

        // POST: Equity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Symbol,Name,IPOyear,SectorId,IndustryId,Quote,SecurityId")] EQUITY eQUITY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eQUITY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IndustryId = new SelectList(db.INDUSTRY, "IndustryId", "IndustryName", eQUITY.IndustryId);
            ViewBag.SectorId = new SelectList(db.SECTOR, "SectorId", "SectorName", eQUITY.SectorId);
            return View(eQUITY);
        }

        // GET: Equity/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EQUITY eQUITY = db.EQUITY.Find(id);
            if (eQUITY == null)
            {
                return HttpNotFound();
            }
            return View(eQUITY);
        }

        // POST: Equity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EQUITY eQUITY = db.EQUITY.Find(id);
            db.EQUITY.Remove(eQUITY);
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
