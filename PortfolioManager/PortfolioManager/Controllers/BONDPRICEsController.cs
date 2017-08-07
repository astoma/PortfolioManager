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
    public class BONDPRICEsController : Controller
    {
        private PortfolioManagerEntities db = new PortfolioManagerEntities();

        // GET: BONDPRICEs
        public ActionResult Index()
        {
            return View(db.BONDPRICE.ToList());
        }

        // GET: BONDPRICEs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BONDPRICE bONDPRICE = db.BONDPRICE.Find(id);
            if (bONDPRICE == null)
            {
                return HttpNotFound();
            }
            return View(bONDPRICE);
        }

        // GET: BONDPRICEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BONDPRICEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BondIssuer,BondPrice1,ExDate")] BONDPRICE bONDPRICE)
        {
            if (ModelState.IsValid)
            {
                db.BONDPRICE.Add(bONDPRICE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bONDPRICE);
        }

        // GET: BONDPRICEs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BONDPRICE bONDPRICE = db.BONDPRICE.Find(id);
            if (bONDPRICE == null)
            {
                return HttpNotFound();
            }
            return View(bONDPRICE);
        }

        // POST: BONDPRICEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BondIssuer,BondPrice1,ExDate")] BONDPRICE bONDPRICE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bONDPRICE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bONDPRICE);
        }

        // GET: BONDPRICEs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BONDPRICE bONDPRICE = db.BONDPRICE.Find(id);
            if (bONDPRICE == null)
            {
                return HttpNotFound();
            }
            return View(bONDPRICE);
        }

        // POST: BONDPRICEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BONDPRICE bONDPRICE = db.BONDPRICE.Find(id);
            db.BONDPRICE.Remove(bONDPRICE);
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
