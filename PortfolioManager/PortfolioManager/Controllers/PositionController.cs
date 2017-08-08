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
    public class PositionController : Controller
    {
        private PortfolioManagerEntity db = new PortfolioManagerEntity();

        // GET: Position
        public ActionResult Index()
        {
            var pOSITION = db.POSITION.Include(p => p.BOND).Include(p => p.EQUITY).Include(p => p.FUTURE).Include(p => p.PORTFOLIO);
            return View(pOSITION.ToList());
        }

        // GET: Position/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POSITION pOSITION = db.POSITION.Find(id);
            if (pOSITION == null)
            {
                return HttpNotFound();
            }
            return View(pOSITION);
        }

        // GET: Position/Create
        public ActionResult Create()
        {
            ViewBag.SecurityId = new SelectList(db.BOND, "SecurityId", "Issuer");
            ViewBag.SecurityId = new SelectList(db.EQUITY, "SecurityId", "Symbol");
            ViewBag.SecurityId = new SelectList(db.FUTURE, "SecurityId", "FutureId");
            ViewBag.PortfolioId = new SelectList(db.PORTFOLIO, "PortfolioId", "PortfolioName");
            return View();
        }

        // POST: Position/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PositionType,SecurityId,PortfolioId,Quantity,PositionId")] POSITION pOSITION)
        {
            if (ModelState.IsValid)
            {
                db.POSITION.Add(pOSITION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SecurityId = new SelectList(db.BOND, "SecurityId", "Issuer", pOSITION.SecurityId);
            ViewBag.SecurityId = new SelectList(db.EQUITY, "SecurityId", "Symbol", pOSITION.SecurityId);
            ViewBag.SecurityId = new SelectList(db.FUTURE, "SecurityId", "FutureId", pOSITION.SecurityId);
            ViewBag.PortfolioId = new SelectList(db.PORTFOLIO, "PortfolioId", "PortfolioName", pOSITION.PortfolioId);
            return View(pOSITION);
        }

        // GET: Position/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POSITION pOSITION = db.POSITION.Find(id);
            if (pOSITION == null)
            {
                return HttpNotFound();
            }
            ViewBag.SecurityId = new SelectList(db.BOND, "SecurityId", "Issuer", pOSITION.SecurityId);
            ViewBag.SecurityId = new SelectList(db.EQUITY, "SecurityId", "Symbol", pOSITION.SecurityId);
            ViewBag.SecurityId = new SelectList(db.FUTURE, "SecurityId", "FutureId", pOSITION.SecurityId);
            ViewBag.PortfolioId = new SelectList(db.PORTFOLIO, "PortfolioId", "PortfolioName", pOSITION.PortfolioId);
            return View(pOSITION);
        }

        // POST: Position/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PositionType,SecurityId,PortfolioId,Quantity,PositionId")] POSITION pOSITION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pOSITION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SecurityId = new SelectList(db.BOND, "SecurityId", "Issuer", pOSITION.SecurityId);
            ViewBag.SecurityId = new SelectList(db.EQUITY, "SecurityId", "Symbol", pOSITION.SecurityId);
            ViewBag.SecurityId = new SelectList(db.FUTURE, "SecurityId", "FutureId", pOSITION.SecurityId);
            ViewBag.PortfolioId = new SelectList(db.PORTFOLIO, "PortfolioId", "PortfolioName", pOSITION.PortfolioId);
            return View(pOSITION);
        }

        // GET: Position/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POSITION pOSITION = db.POSITION.Find(id);
            if (pOSITION == null)
            {
                return HttpNotFound();
            }
            return View(pOSITION);
        }

        // POST: Position/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            POSITION pOSITION = db.POSITION.Find(id);
            db.POSITION.Remove(pOSITION);
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
