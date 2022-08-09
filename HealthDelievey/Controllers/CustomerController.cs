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
    public class CustomerController : Controller
    {
        private HealthDeliveryDBEntities db = new HealthDeliveryDBEntities();

        // GET: Customer
        public ActionResult Index()
        {
            return View(db.h_customer.ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            h_customer h_customer = db.h_customer.Find(id);
            if (h_customer == null)
            {
                return HttpNotFound();
            }
            return View(h_customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,age,gender,phone")] h_customer h_customer)
        {
            if (ModelState.IsValid)
            {
                db.h_customer.Add(h_customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(h_customer);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            h_customer h_customer = db.h_customer.Find(id);
            if (h_customer == null)
            {
                return HttpNotFound();
            }
            return View(h_customer);
        }

        // POST: Customer/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,age,gender,phone")] h_customer h_customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(h_customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(h_customer);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            h_customer h_customer = db.h_customer.Find(id);
            if (h_customer == null)
            {
                return HttpNotFound();
            }
            return View(h_customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            h_customer h_customer = db.h_customer.Find(id);
            db.h_customer.Remove(h_customer);
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
