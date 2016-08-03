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
    public class SprintController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Sprint
        public IQueryable<SprintModel> GetSprintModels()
        {
            return db.SprintModels;
        }

        // GET: api/Sprint/5
        [ResponseType(typeof(SprintModel))]
        public IHttpActionResult GetSprintModel(int id)
        {
            SprintModel sprintModel = db.SprintModels.Find(id);
            if (sprintModel == null)
            {
                return NotFound();
            }

            return Ok(sprintModel);
        }

        // PUT: api/Sprint/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSprintModel(int id, SprintModel sprintModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sprintModel.SprintId)
            {
                return BadRequest();
            }

            db.Entry(sprintModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SprintModelExists(id))
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

        // POST: api/Sprint
        [ResponseType(typeof(SprintModel))]
        public IHttpActionResult PostSprintModel(SprintModel sprintModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SprintModels.Add(sprintModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sprintModel.SprintId }, sprintModel);
        }

        // DELETE: api/Sprint/5
        [ResponseType(typeof(SprintModel))]
        public IHttpActionResult DeleteSprintModel(int id)
        {
            SprintModel sprintModel = db.SprintModels.Find(id);
            if (sprintModel == null)
            {
                return NotFound();
            }

            db.SprintModels.Remove(sprintModel);
            db.SaveChanges();

            return Ok(sprintModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SprintModelExists(int id)
        {
            return db.SprintModels.Count(e => e.SprintId == id) > 0;
        }
    }
}