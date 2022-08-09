using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HealthDelievey.Models;

namespace HealthDelievey.Controllers
{
    public class ServiceController : Controller
    {
        private HealthDeliveryDBEntities db = new HealthDeliveryDBEntities();

        // GET: Service
        public ActionResult Index()
        {
            return View(db.h_service.ToList());
        }

        // GET: Service/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            h_service h_service = db.h_service.Find(id);
            if (h_service == null)
            {
                return HttpNotFound();
            }
            return View(h_service);
        }

        // GET: Service/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Service/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,type,price,duration")] h_service h_service)
        {
            if (ModelState.IsValid)
            {
                db.h_service.Add(h_service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(h_service);
        }

        // GET: Service/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            h_service h_service = db.h_service.Find(id);
            if (h_service == null)
            {
                return HttpNotFound();
            }
            return View(h_service);
        }

        // POST: Service/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,type,price,duration")] h_service h_service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(h_service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(h_service);
        }

        // GET: Service/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            h_service h_service = db.h_service.Find(id);
            if (h_service == null)
            {
                return HttpNotFound();
            }
            return View(h_service);
        }

        // POST: Service/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            h_service h_service = db.h_service.Find(id);
            db.h_service.Remove(h_service);
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
