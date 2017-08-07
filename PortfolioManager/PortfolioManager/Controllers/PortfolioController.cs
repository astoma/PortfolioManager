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
    public class PortfolioController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();

        // GET: Portfolio
        public ActionResult Index()
        {
            var pORTFOLIO = db.PORTFOLIO.Include(p => p.USER);
            return View(pORTFOLIO.ToList());
        }

        // GET: Portfolio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PORTFOLIO pORTFOLIO = db.PORTFOLIO.Find(id);
            if (pORTFOLIO == null)
            {
                return HttpNotFound();
            }
            return View(pORTFOLIO);
        }

        // GET: Portfolio/Create
        public ActionResult Create()
        {
            ViewBag.ManagerId = new SelectList(db.USER, "UserId", "UserName");
            return View();
        }

        // POST: Portfolio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PortfolioName,ManagerId,PortfolioId")] PORTFOLIO pORTFOLIO)
        {
            if (ModelState.IsValid)
            {
                db.PORTFOLIO.Add(pORTFOLIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManagerId = new SelectList(db.USER, "UserId", "UserName", pORTFOLIO.ManagerId);
            return View(pORTFOLIO);
        }

        // GET: Portfolio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PORTFOLIO pORTFOLIO = db.PORTFOLIO.Find(id);
            if (pORTFOLIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManagerId = new SelectList(db.USER, "UserId", "UserName", pORTFOLIO.ManagerId);
            return View(pORTFOLIO);
        }

        // POST: Portfolio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PortfolioName,ManagerId,PortfolioId")] PORTFOLIO pORTFOLIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pORTFOLIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManagerId = new SelectList(db.USER, "UserId", "UserName", pORTFOLIO.ManagerId);
            return View(pORTFOLIO);
        }

        // GET: Portfolio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PORTFOLIO pORTFOLIO = db.PORTFOLIO.Find(id);
            if (pORTFOLIO == null)
            {
                return HttpNotFound();
            }
            return View(pORTFOLIO);
        }

        // POST: Portfolio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PORTFOLIO pORTFOLIO = db.PORTFOLIO.Find(id);
            db.PORTFOLIO.Remove(pORTFOLIO);
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
