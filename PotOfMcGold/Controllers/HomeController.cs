using PotOfMcGold.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PotOfMcGold.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext dbcontext;

        public HomeController()
        {
            dbcontext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            dbcontext.Dispose();
        }

        public ActionResult Index()
        {
            var portfolios = dbcontext.Portfolios.ToList();
            return View(portfolios);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}