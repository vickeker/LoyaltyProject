using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BarController : ApiController
    {
        private WebApplication1Context db = new WebApplication1Context();

        // GET: api/Bar
        public IQueryable<Bar> GetBar()
        {
            return db.Bar;
        }

        // GET: api/Bar/5
        [ResponseType(typeof(Bar))]
        public async Task<IHttpActionResult> GetBar(int id)
        {
            Bar Bar = await db.Bar.FindAsync(id);
            if (Bar == null)
            {
                return NotFound();
            }

            return Ok(Bar);
        }

        // PUT: api/Bar/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBar(int id, Bar Bar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Bar.BarId)
            {
                return BadRequest();
            }

            db.Entry(Bar).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarExists(id))
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

        // POST: api/Bar
        [ResponseType(typeof(Bar))]
        public async Task<IHttpActionResult> PostBar(Bar Bar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bar.Add(Bar);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = Bar.BarId }, Bar);
        }

        // DELETE: api/Bar/5
        [ResponseType(typeof(Bar))]
        public async Task<IHttpActionResult> DeleteBar(int id)
        {
            Bar Bar = await db.Bar.FindAsync(id);
            if (Bar == null)
            {
                return NotFound();
            }

            db.Bar.Remove(Bar);
            await db.SaveChangesAsync();

            return Ok(Bar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BarExists(int id)
        {
            return db.Bar.Count(e => e.BarId == id) > 0;
        }
    }
}