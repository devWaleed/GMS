﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StockManager.Models;
using PagedList;
namespace StockManager.Controllers
{
    [Authorize]
    public class PrinterChalansController : Controller
    {
        private StockManagerEntities db = new StockManagerEntities();

        // GET: PrinterChalans
        public ActionResult Index(int? page)
        {
            var year_id = Convert.ToInt32(Session["FinancialYearID"]);
            var CompanyId = Convert.ToInt32(Session["CompanyID"]);
            var printerChalans = db.PrinterChalans
                .Include(p => p.Vendor)
                .Include(p => p.PrinterChalanDetails)
                .Where(x => x.financial_year == year_id && x.CompanyId == CompanyId).OrderBy(x => x.ChalanDate);

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(printerChalans.ToPagedList(pageNumber, pageSize));
            //return View(printerChalans);
        }

        // GET: PrinterChalans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int companyId = Convert.ToInt32(Session["CompanyID"]);
            PrinterChalan printerChalan = db.PrinterChalans.Where(x => x.CompanyId == companyId && x.Id == id).FirstOrDefault();
            if (printerChalan == null)
            {
                return HttpNotFound();
            }
            return View(printerChalan);
        }

        // GET: PrinterChalans/Create
        public ActionResult Create()
        {
            int companyId = Convert.ToInt32(Session["CompanyID"]);
            ViewBag.ProductId = new SelectList(db.Products.Where(x => x.ProductTypeId == 1 && x.IsActive == true && x.CompanyId == companyId), "Id", "ProductName");
            ViewBag.VendorId = new SelectList(db.Vendors.Where(x => x.VendorTypeId == 2 && x.CompanyId == companyId), "Id", "VendorName");
            var year_id = Session["FinancialYearID"];
            var year = db.FinancialYears.Find(year_id);

            ViewBag.StartYear = year.StartDate.ToString("dd-MMM-yyyy");
            ViewBag.EndYear = year.EndDate.ToString("dd-MMM-yyyy");

            var last = db.PrinterChalans.Where(x => x.CompanyId == companyId).OrderByDescending(o => o.chalan_number).FirstOrDefault();

            if (last == null)
            {
                ViewBag.chalan_number = 1;
            }
            else
            {
                ViewBag.chalan_number = last.chalan_number + 1;
            }

            return View();
        }

        // POST: PrinterChalans/Create       
        [HttpPost]
        public JsonResult Create(PrinterChalan printerChalan)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                var year_id = Convert.ToInt32(Session["FinancialYearID"]);
                var CompanyId = Convert.ToInt32(Session["CompanyID"]);
                var creaded_by = Convert.ToInt32(Session["UserID"]);
                try
                {
                    
                    DateTime dtDate = DateTime.Now;
                    printerChalan.Created = dtDate;
                    printerChalan.Updated = dtDate;
                    printerChalan.created_by = creaded_by;
                    printerChalan.financial_year = year_id;
                    printerChalan.CompanyId = CompanyId;

                    db.PrinterChalans.Add(printerChalan);
                    db.SaveChanges();
                    int scope_id = printerChalan.Id;
                    transaction.Commit();
                    return Json(Convert.ToString(scope_id));
                }
                catch
                {
                    transaction.Rollback();
                    ViewBag.VendorId = new SelectList(db.Vendors.Where(x => x.VendorTypeId == 2 && x.CompanyId == CompanyId), "Id", "VendorName", printerChalan.VendorId);
                    ViewBag.ProductId = new SelectList(db.Products.Where(x => x.ProductTypeId == 1 && x.IsActive == true && x.CompanyId == CompanyId), "Id", "ProductName");
                }
            }
            return Json("0");
        }

        // GET: PrinterChalans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int companyId = Convert.ToInt32(Session["CompanyID"]);
            PrinterChalan printerChalan = db.PrinterChalans.Where(x => x.CompanyId == companyId && x.Id == id).FirstOrDefault();
            if (printerChalan == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.ProductId = new SelectList(db.Products.Where(x => x.ProductTypeId == 1 && x.IsActive == true && x.CompanyId == companyId), "Id", "ProductName", printerChalan.VendorId);
            ViewBag.VendorId = new SelectList(db.Vendors.Where(x => x.VendorTypeId == 2 && x.CompanyId == companyId), "Id", "VendorName", printerChalan.VendorId);
            var year_id = Session["FinancialYearID"];
            var year = db.FinancialYears.Find(year_id);

            ViewBag.StartYear = year.StartDate.ToString("dd-MMM-yyyy");
            ViewBag.EndYear = year.EndDate.ToString("dd-MMM-yyyy");
            return View(printerChalan);
        }

        // POST: PrinterChalans/Edit/5        
        [HttpPost]
        public JsonResult Edit(PrinterChalan printerChalan)
        {
            int companyId = Convert.ToInt32(Session["CompanyID"]);
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var objPurchaseDetails in printerChalan.PrinterChalanDetails)
                    {
                        if (objPurchaseDetails.Id == 0)
                        {
                            db.Entry(objPurchaseDetails).State = EntityState.Added;
                            db.SaveChanges();
                        }
                    }

                    while (printerChalan.PrinterChalanDetails.Where(x => x.Id == 0).Count() > 0)
                        printerChalan.PrinterChalanDetails.Remove(printerChalan.PrinterChalanDetails.Where(x => x.Id == 0).ToList()[0]);

                    DateTime dtDate = DateTime.Now;
                    printerChalan.Updated = dtDate;
                    db.Entry(printerChalan).State = EntityState.Modified;
                    db.SaveChanges();

                    transaction.Commit();
                    return Json(Convert.ToString(printerChalan.Id));
                }
                catch
                {
                    transaction.Rollback();
                    ViewBag.VendorId = new SelectList(db.Vendors.Where(x => x.VendorTypeId == 2 && x.CompanyId == companyId), "Id", "VendorName", printerChalan.VendorId);
                    ViewBag.ProductId = new SelectList(db.Products.Where(x => x.ProductTypeId == 1 && x.IsActive == true && x.CompanyId == companyId), "Id", "ProductName");
                }
            }
            return Json("0");
        }

        // GET: PrinterChalans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int companyId = Convert.ToInt32(Session["CompanyID"]);
            PrinterChalan printerChalan = db.PrinterChalans.Where(x => x.CompanyId == companyId && x.Id == id).FirstOrDefault();
            db.PrinterChalans.Remove(printerChalan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult DeleteProduct(int? id)
        {
            if (id == null)
            {
                return Json("Error in deleting product.");
            }
            try
            {
                if (id != null && id != 0)
                {
                    PrinterChalanDetail printerChalanDetail = (PrinterChalanDetail)db.PrinterChalanDetails.Where(x => x.Id == id).FirstOrDefault();
                    db.PrinterChalanDetails.Remove(printerChalanDetail);
                    db.SaveChanges();
                    return Json("product deleted Successfully.");
                }
            }
            catch
            {
            }
            return Json("Error in deleting product.");
        }

        [ActionName("print-single")]
        public ActionResult SinglePrint(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int companyId = Convert.ToInt32(Session["CompanyID"]);
            PrinterChalan printerChalan = db.PrinterChalans.Where(x => x.CompanyId == companyId && x.Id == id).FirstOrDefault();
            
            if (printerChalan != null)
            {
                string footer = String.Format("--footer-center \"E & O.E. - Subject to Jaipur Jurisdiction only - For {0}\"", printerChalan.Company.Name);

                PrinterModel pm = new PrinterModel()
                {
                    No = printerChalan.Id,
                    Company = printerChalan.Company,
                    CreatedOn = (printerChalan.Created.HasValue) ? printerChalan.Created.Value : DateTime.Now,
                    Customer = printerChalan.Vendor.VendorName,
                    ShowTotal = false,
                    Items = printerChalan.PrinterChalanDetails.Select(x => new PrinterItem()
                    {
                        Particular = x.Product.ProductName + " (" + x.ExpectedFold + ") ",
                        Pcs = Convert.ToInt32(x.Quantity),
                    })
                    .ToList()
                };

                return new Rotativa.ViewAsPdf("SinglePrint", pm)
                {
                    PageSize = Rotativa.Options.Size.A4,
                    CustomSwitches = footer
                };
            }

            return HttpNotFound();            

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
