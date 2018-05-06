using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BenABurgessWebApp.Models;
using BenABurgessWebApp.Models.DAL;
using Microsoft.AspNet.Identity;

namespace BenABurgessWebApp.Controllers
{
    [RequireHttps]
    [Authorize]
    public class FinancialController : Controller
    {
        private FinancialContext db = new FinancialContext();

        private Financial context = new Financial();
        


        // GET: Financial
        public ActionResult Index()
        {
            
            return View(context);
        }
        // GET: Financial/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var financial = context.Id;
            if (financial == null)
            {
                return HttpNotFound();
            }
            return View(financial);
        }

        // GET: Financial/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Financial/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,Symbol,Name,Shares,Price,TOTAL")] Financial financial)
        {
            if (ModelState.IsValid)
            {
                financial.Id = Guid.NewGuid();
                financial.UserId = User.Identity.GetUserId();
                db.Financials.Add(financial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(financial);
        }

        // GET: Financial/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Financial financial = db.Financials.Find(id);
            if (financial == null)
            {
                return HttpNotFound();
            }
            return View(financial);
        }

        // POST: Financial/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,Symbol,Name,Shares,Price,TOTAL")] Financial financial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(financial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(financial);
        }

        // GET: Financial/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Financial financial = db.Financials.Find(id);
            if (financial == null)
            {
                return HttpNotFound();
            }
            return View(financial);
        }

        // POST: Financial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Financial financial = db.Financials.Find(id);
            db.Financials.Remove(financial);
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
