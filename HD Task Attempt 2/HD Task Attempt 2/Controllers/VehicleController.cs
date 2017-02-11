using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HD_Task_Attempt_2.Models;

namespace HD_Task_Attempt_2.Controllers
{
    public class VehicleController : Controller
    {
        private WarrantyDatabaseEntities db = new WarrantyDatabaseEntities();

        // GET: /Vehicle/
        public ActionResult Index()
        {
            var vehicles = db.Vehicles.Include(v => v.Manufacturer);
            return View(vehicles.ToList());
        }

        // GET: /Vehicle/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: /Vehicle/Create
        public ActionResult Create()
        {
            ViewBag.ManID = new SelectList(db.Manufacturers, "ManID", "ManName");
            return View();
        }

        // POST: /Vehicle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="VIN,vehMake,vehModel,vehYear,vehTrim,vehCost,vehPrice,vehQuantity,ManID")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManID = new SelectList(db.Manufacturers, "ManID", "ManName", vehicle.ManID);
            return View(vehicle);
        }

        // GET: /Vehicle/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManID = new SelectList(db.Manufacturers, "ManID", "ManName", vehicle.ManID);
            return View(vehicle);
        }

        // POST: /Vehicle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="VIN,vehMake,vehModel,vehYear,vehTrim,vehCost,vehPrice,vehQuantity,ManID")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManID = new SelectList(db.Manufacturers, "ManID", "ManName", vehicle.ManID);
            return View(vehicle);
        }

        // GET: /Vehicle/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: /Vehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
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
