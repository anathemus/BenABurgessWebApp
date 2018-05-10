using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using BenABurgessWebApp.Models;
using System.Security.Principal;

namespace BenABurgessWebApp.Controllers
{
    public class AccountTransactionsController : Controller
    {
        private static ApplicationDbContext db = new ApplicationDbContext();        

        // GET: AccountTransactions
        public async Task<ActionResult> Index()
        {
            var accountTransactions = db.AccountTransactions.Include(a => a.FinancialAccount);
            return View(await accountTransactions.ToListAsync());
        }

        // GET: AccountTransactions/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountTransaction accountTransaction = await db.AccountTransactions.FindAsync(id);
            if (accountTransaction == null)
            {
                return HttpNotFound();
            }
            return View(accountTransaction);
        }

        // GET: AccountTransactions/Create
        public ActionResult Create()
        {
            ViewBag.TransactionsAccountId = new SelectList(db.FinancialAccounts, "TransactionsAccountId", "UserName");
            return View();
        }

        // POST: AccountTransactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TransactionId,TransactionsAccountId,Symbol,CompanyName,Shares,PriceAtPurchase,TotalAtPurchase,PriceAtSale,TotalAtSale")] AccountTransaction accountTransaction)
        {
            if (ModelState.IsValid)
            {
                accountTransaction.TransactionId = Guid.NewGuid();
                db.AccountTransactions.Add(accountTransaction);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TransactionsAccountId = new SelectList(db.FinancialAccounts, "TransactionsAccountId", "UserName", accountTransaction.TransactionsAccountId);
            return View(accountTransaction);
        }

        // GET: AccountTransactions/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountTransaction accountTransaction = await db.AccountTransactions.FindAsync(id);
            if (accountTransaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.TransactionsAccountId = new SelectList(db.FinancialAccounts, "TransactionsAccountId", "UserName", accountTransaction.TransactionsAccountId);
            return View(accountTransaction);
        }

        // POST: AccountTransactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TransactionId,TransactionsAccountId,Symbol,CompanyName,Shares,PriceAtPurchase,TotalAtPurchase,PriceAtSale,TotalAtSale")] AccountTransaction accountTransaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountTransaction).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TransactionsAccountId = new SelectList(db.FinancialAccounts, "TransactionsAccountId", "UserName", accountTransaction.TransactionsAccountId);
            return View(accountTransaction);
        }

        // GET: AccountTransactions/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountTransaction accountTransaction = await db.AccountTransactions.FindAsync(id);
            if (accountTransaction == null)
            {
                return HttpNotFound();
            }
            return View(accountTransaction);
        }

        // POST: AccountTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            AccountTransaction accountTransaction = await db.AccountTransactions.FindAsync(id);
            db.AccountTransactions.Remove(accountTransaction);
            await db.SaveChangesAsync();
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
