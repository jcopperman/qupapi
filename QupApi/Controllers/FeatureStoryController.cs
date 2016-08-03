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
    public class FeatureStoryController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/FeatureStory
        public IQueryable<FeatureStoryModel> GetFeatureStoryModels()
        {
            return db.FeatureStoryModels;
        }

        // GET: api/FeatureStory/5
        [ResponseType(typeof(FeatureStoryModel))]
        public IHttpActionResult GetFeatureStoryModel(int id)
        {
            FeatureStoryModel featureStoryModel = db.FeatureStoryModels.Find(id);
            if (featureStoryModel == null)
            {
                return NotFound();
            }

            return Ok(featureStoryModel);
        }

        // PUT: api/FeatureStory/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFeatureStoryModel(int id, FeatureStoryModel featureStoryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != featureStoryModel.FeatureStoryId)
            {
                return BadRequest();
            }

            db.Entry(featureStoryModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeatureStoryModelExists(id))
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

        // POST: api/FeatureStory
        [ResponseType(typeof(FeatureStoryModel))]
        public IHttpActionResult PostFeatureStoryModel(FeatureStoryModel featureStoryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FeatureStoryModels.Add(featureStoryModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = featureStoryModel.FeatureStoryId }, featureStoryModel);
        }

        // DELETE: api/FeatureStory/5
        [ResponseType(typeof(FeatureStoryModel))]
        public IHttpActionResult DeleteFeatureStoryModel(int id)
        {
            FeatureStoryModel featureStoryModel = db.FeatureStoryModels.Find(id);
            if (featureStoryModel == null)
            {
                return NotFound();
            }

            db.FeatureStoryModels.Remove(featureStoryModel);
            db.SaveChanges();

            return Ok(featureStoryModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FeatureStoryModelExists(int id)
        {
            return db.FeatureStoryModels.Count(e => e.FeatureStoryId == id) > 0;
        }
    }
}