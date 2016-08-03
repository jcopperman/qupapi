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
    public class UserStoryController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/UserStory
        public IQueryable<UserStoryModel> GetUserStoryModels()
        {
            return db.UserStoryModels;
        }

        // GET: api/UserStory/5
        [ResponseType(typeof(UserStoryModel))]
        public IHttpActionResult GetUserStoryModel(int id)
        {
            UserStoryModel userStoryModel = db.UserStoryModels.Find(id);
            if (userStoryModel == null)
            {
                return NotFound();
            }

            return Ok(userStoryModel);
        }

        // PUT: api/UserStory/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserStoryModel(int id, UserStoryModel userStoryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userStoryModel.UserStoryId)
            {
                return BadRequest();
            }

            db.Entry(userStoryModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserStoryModelExists(id))
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

        // POST: api/UserStory
        [ResponseType(typeof(UserStoryModel))]
        public IHttpActionResult PostUserStoryModel(UserStoryModel userStoryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserStoryModels.Add(userStoryModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userStoryModel.UserStoryId }, userStoryModel);
        }

        // DELETE: api/UserStory/5
        [ResponseType(typeof(UserStoryModel))]
        public IHttpActionResult DeleteUserStoryModel(int id)
        {
            UserStoryModel userStoryModel = db.UserStoryModels.Find(id);
            if (userStoryModel == null)
            {
                return NotFound();
            }

            db.UserStoryModels.Remove(userStoryModel);
            db.SaveChanges();

            return Ok(userStoryModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserStoryModelExists(int id)
        {
            return db.UserStoryModels.Count(e => e.UserStoryId == id) > 0;
        }
    }
}