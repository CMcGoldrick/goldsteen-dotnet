using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PotOfMcGold.Models;

namespace PotOfMcGold.Controllers
{
    public class PortfoliosController : Controller
    {
        private ApplicationDbContext dbcontext;

        public PortfoliosController()
        {
            dbcontext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            dbcontext.Dispose();
        }

        // GET: portfolios/index
        public ActionResult Index()
        {
            var portfolios = dbcontext.Portfolios.ToList();
            return View(portfolios);
        }

        // POST /portfolios/delete/int
        public ActionResult Delete(int id)
        {
            Portfolio portfolio = dbcontext.Portfolios.Find(id);
            dbcontext.Portfolios.Remove(portfolio);
            dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }

        // POST /portfolios/save
        [HttpPost]
        public ActionResult Save(string name, float volume, string notes)
        {
            var portfolio = new Portfolio
            {
                Name = name,
                Volume = volume,
                Notes = notes
            };

            dbcontext.Portfolios.Add(portfolio);
            dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET /portfolios/editview
        public ActionResult EditView(int id)
        {
            Portfolio portfolio = dbcontext.Portfolios.Find(id);

            return View(portfolio);
        }

        // POST /portfolios/edit/int
        public ActionResult Edit(int id, string name, float volume, string notes)
        {
            Portfolio portfolio = dbcontext.Portfolios.Find(id);

            portfolio.Name = name;
            portfolio.Volume = volume;
            portfolio.Notes = notes;

            dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}