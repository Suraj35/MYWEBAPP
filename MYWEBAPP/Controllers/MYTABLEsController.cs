using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MYWEBAPP.Models;

namespace MYWEBAPP.Controllers
{
    public class MYTABLEsController : Controller
    {
        private MYDBEntities db = new MYDBEntities();

        // ccccc GET: MYTABLEs
        public ActionResult Index()
        {
            return View(db.MYTABLEs.ToList());
        }

        // GET: MYTABLEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MYTABLE mYTABLE = db.MYTABLEs.Find(id);
            if (mYTABLE == null)
            {
                return HttpNotFound();
            }
            return View(mYTABLE);
        }

        // GET: MYTABLEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MYTABLEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,Title,Band,Length")] MYTABLE mYTABLE)
        {
            if (ModelState.IsValid)
            {
                db.MYTABLEs.Add(mYTABLE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mYTABLE);
        }

        // GET: MYTABLEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MYTABLE mYTABLE = db.MYTABLEs.Find(id);
            if (mYTABLE == null)
            {
                return HttpNotFound();
            }
            return View(mYTABLE);
        }

        // POST: MYTABLEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Username,Title,Band,Length")] MYTABLE mYTABLE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mYTABLE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mYTABLE);
        }

        // GET: MYTABLEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MYTABLE mYTABLE = db.MYTABLEs.Find(id);
            if (mYTABLE == null)
            {
                return HttpNotFound();
            }
            return View(mYTABLE);
        }

        // POST: MYTABLEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MYTABLE mYTABLE = db.MYTABLEs.Find(id);
            db.MYTABLEs.Remove(mYTABLE);
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
