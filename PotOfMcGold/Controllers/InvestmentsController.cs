using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PotOfMcGold.Models;

namespace PotOfMcGold.Controllers
{
    [Authorize]
    public class InvestmentsController : Controller
    {
        private ApplicationDbContext _context;

        public InvestmentsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /investments/index
        public ActionResult Index()
        {
            var investments = _context.Investments.ToList();

            return View(investments);
        }

        // POST /investments/delete/int
        public ActionResult Delete(int id)
        {
            Investment investment = _context.Investments.Find(id);
            _context.Investments.Remove(investment);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // POST /investments/save
        [HttpPost]
        public ActionResult Save(string name, float amount, float? volume, string date, string exchange, string notes)
        {
            var investment = new Investment
            {
                Name = name,
                Amount = amount,
                Volume = volume,
                Date = Convert.ToDateTime(date),
                Exchange = exchange,
                Notes = notes,
            };

            _context.Investments.Add(investment);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET /investments/editview
        public ActionResult EditView(int id)
        {
            Investment investment = _context.Investments.Find(id);

            return View(investment);
        }

        // POST /investments/edit/int
        public ActionResult Edit(int id, string name, float amount, float? volume, string date, string exchange, string notes)
        {
            Investment investment = _context.Investments.Find(id);

            investment.Name = name;
            investment.Amount = amount;
            investment.Volume = volume;
            investment.Date = Convert.ToDateTime(date);
            investment.Exchange = exchange;
            investment.Notes = notes;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
