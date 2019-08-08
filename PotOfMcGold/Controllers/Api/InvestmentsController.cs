using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PotOfMcGold.Models;

namespace PotOfMcGold.Controllers.Api
{
    public class InvestmentsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Investments
        public IQueryable<Investment> GetInvestments()
        {
            return db.Investments;
        }

        // GET: api/Investments/5
        [ResponseType(typeof(Investment))]
        public IHttpActionResult GetInvestment(int id)
        {
            Investment investment = db.Investments.Find(id);
            if (investment == null)
            {
                return NotFound();
            }

            return Ok(investment);
        }

        // PUT: api/Investments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInvestment(int id, Investment investment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != investment.Id)
            {
                return BadRequest();
            }

            db.Entry(investment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Investments
        [ResponseType(typeof(Investment))]
        public IHttpActionResult PostInvestment(Investment investment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Investments.Add(investment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = investment.Id }, investment);
        }

        // DELETE: api/Investments/5
        [ResponseType(typeof(Investment))]
        public IHttpActionResult DeleteInvestment(int id)
        {
            Investment investment = db.Investments.Find(id);
            if (investment == null)
            {
                return NotFound();
            }

            db.Investments.Remove(investment);
            db.SaveChanges();

            return Ok(investment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InvestmentExists(int id)
        {
            return db.Investments.Count(e => e.Id == id) > 0;
        }
    }
}