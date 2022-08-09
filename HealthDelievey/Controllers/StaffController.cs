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
    public class StaffController : Controller
    {
        private HealthDeliveryDBEntities db = new HealthDeliveryDBEntities();

        // GET: Staff
        public ActionResult Index()
        {
            return View(db.h_staff.ToList());
        }

        // GET: Staff/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            h_staff h_staff = db.h_staff.Find(id);
            if (h_staff == null)
            {
                return HttpNotFound();
            }
            return View(h_staff);
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,age,phone,position,salary,entrydate")] h_staff h_staff)
        {
            if (ModelState.IsValid)
            {
                db.h_staff.Add(h_staff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(h_staff);
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            h_staff h_staff = db.h_staff.Find(id);
            if (h_staff == null)
            {
                return HttpNotFound();
            }
            return View(h_staff);
        }

        // POST: Staff/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,age,phone,position,salary,entrydate")] h_staff h_staff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(h_staff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(h_staff);
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            h_staff h_staff = db.h_staff.Find(id);
            if (h_staff == null)
            {
                return HttpNotFound();
            }
            return View(h_staff);
        }

        // POST: Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            h_staff h_staff = db.h_staff.Find(id);
            db.h_staff.Remove(h_staff);
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
