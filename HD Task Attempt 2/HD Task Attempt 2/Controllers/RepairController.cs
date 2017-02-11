using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.Mvc;
using System.IO;
using System.Text;
using HD_Task_Attempt_2.Models;


namespace HD_Task_Attempt_2.Controllers
{
    public class RepairController : Controller
    {
        private WarrantyDatabaseEntities db = new WarrantyDatabaseEntities();

        // GET: /Repair/
        public ActionResult Index()
        {
            var repairs = db.Repairs.Include(r => r.Vehicle);
            return View(repairs.OrderBy(r => r.repDate).ToList());
        }

        // GET: /Repair/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repair repair = db.Repairs.Find(id);
            if (repair == null)
            {
                return HttpNotFound();
            }
            return View(repair);
        }

        // GET: /Repair/Create
        public ActionResult Create()
        {
            ViewBag.VIN = new SelectList(db.Vehicles, "VIN", "vehMake");
            return View();
        }

        // POST: /Repair/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="RepairID,repDate,repDesc,repMechanic,repOdometer,repCost,repPrice,repReturned,VIN")] Repair repair)
        {
            if (ModelState.IsValid)
            {
                db.Repairs.Add(repair);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VIN = new SelectList(db.Vehicles, "VIN", "vehMake", repair.VIN);
            return View(repair);
        }

        // GET: /Repair/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repair repair = db.Repairs.Find(id);
            if (repair == null)
            {
                return HttpNotFound();
            }
            ViewBag.VIN = new SelectList(db.Vehicles, "VIN", "vehMake", repair.VIN);
            return View(repair);
        }

        // POST: /Repair/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="RepairID,repDate,repDesc,repMechanic,repOdometer,repCost,repPrice,repReturned,VIN")] Repair repair)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repair).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VIN = new SelectList(db.Vehicles, "VIN", "vehMake", repair.VIN);
            return View(repair);
        }

        // GET: /Repair/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repair repair = db.Repairs.Find(id);
            if (repair == null)
            {
                return HttpNotFound();
            }
            return View(repair);
        }

        // POST: /Repair/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Repair repair = db.Repairs.Find(id);
            db.Repairs.Remove(repair);
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

        public void ExportClientsListToCSV()
        {

            StringWriter sw = new StringWriter();

            sw.WriteLine("\"repDate\",\"repDesc\",\"repMechanic\",\"repOdometer\",\"repCost\",\"repPrice\",\"repReturned\",\"VIN\"");

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=Exported_Users.csv");
            Response.ContentType = "text/csv";

            foreach (var r in db.Repairs)
            {
                sw.WriteLine(string.Format("\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\"",
                                           r.repDate,
                                           r.repDesc,
                                           r.repMechanic,
                                           r.repOdometer,
                                           r.repCost,
                                           r.repPrice,
                                           r.repReturned,
                                           r.VIN));
            }

            Response.Write(sw.ToString());

            Response.End();

        }

        public void ExportClientsListToExcel()
        {
            var grid = new System.Web.UI.WebControls.GridView();

            grid.DataSource = (from r in db.Repairs
                              select new
                              {
                                  RepairDate = r.repDate,
                                  RepairDescription = r.repDesc,
                                  RepairMechanic = r.repMechanic,
                                  RepairOdometer = r.repOdometer,
                                  RepairCost = r.repCost,
                                  RepairPrice = r.repPrice,
                                  RepairReturned = r.repReturned,
                                  RepairedVIN = r.VIN

                              }).ToList();

            grid.DataBind();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Exported_Repairs.xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Write(sw.ToString());

            Response.End();

        }
    }
}
