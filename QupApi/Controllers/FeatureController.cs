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
    public class FeatureController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Feature
        public IQueryable<FeatureModel> GetFeatureModels()
        {
            return db.FeatureModels;
        }

        // GET: api/Feature/5
        [ResponseType(typeof(FeatureModel))]
        public IHttpActionResult GetFeatureModel(int id)
        {
            FeatureModel featureModel = db.FeatureModels.Find(id);
            if (featureModel == null)
            {
                return NotFound();
            }

            return Ok(featureModel);
        }

        // PUT: api/Feature/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFeatureModel(int id, FeatureModel featureModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != featureModel.FeatureId)
            {
                return BadRequest();
            }

            db.Entry(featureModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeatureModelExists(id))
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

        // POST: api/Feature
        [ResponseType(typeof(FeatureModel))]
        public IHttpActionResult PostFeatureModel(FeatureModel featureModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FeatureModels.Add(featureModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = featureModel.FeatureId }, featureModel);
        }

        // DELETE: api/Feature/5
        [ResponseType(typeof(FeatureModel))]
        public IHttpActionResult DeleteFeatureModel(int id)
        {
            FeatureModel featureModel = db.FeatureModels.Find(id);
            if (featureModel == null)
            {
                return NotFound();
            }

            db.FeatureModels.Remove(featureModel);
            db.SaveChanges();

            return Ok(featureModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FeatureModelExists(int id)
        {
            return db.FeatureModels.Count(e => e.FeatureId == id) > 0;
        }
    }
}