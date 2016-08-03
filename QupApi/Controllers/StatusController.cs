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
using QupApi.Models;

namespace QupApi.Controllers
{
    public class StatusController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Status
        public IQueryable<StatusModel> GetStatusModels()
        {
            return db.StatusModels;
        }

        // GET: api/Status/5
        [ResponseType(typeof(StatusModel))]
        public IHttpActionResult GetStatusModel(int id)
        {
            StatusModel statusModel = db.StatusModels.Find(id);
            if (statusModel == null)
            {
                return NotFound();
            }

            return Ok(statusModel);
        }

        // PUT: api/Status/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatusModel(int id, StatusModel statusModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statusModel.StatusId)
            {
                return BadRequest();
            }

            db.Entry(statusModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusModelExists(id))
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

        // POST: api/Status
        [ResponseType(typeof(StatusModel))]
        public IHttpActionResult PostStatusModel(StatusModel statusModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatusModels.Add(statusModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = statusModel.StatusId }, statusModel);
        }

        // DELETE: api/Status/5
        [ResponseType(typeof(StatusModel))]
        public IHttpActionResult DeleteStatusModel(int id)
        {
            StatusModel statusModel = db.StatusModels.Find(id);
            if (statusModel == null)
            {
                return NotFound();
            }

            db.StatusModels.Remove(statusModel);
            db.SaveChanges();

            return Ok(statusModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatusModelExists(int id)
        {
            return db.StatusModels.Count(e => e.StatusId == id) > 0;
        }
    }
}