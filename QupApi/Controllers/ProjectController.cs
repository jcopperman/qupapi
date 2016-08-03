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
    public class ProjectController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Project
        public IQueryable<ProjectModel> GetProjectModels()
        {
            return db.ProjectModels;
        }

        // GET: api/Project/5
        [ResponseType(typeof(ProjectModel))]
        public IHttpActionResult GetProjectModel(int id)
        {
            ProjectModel projectModel = db.ProjectModels.Find(id);
            if (projectModel == null)
            {
                return NotFound();
            }

            return Ok(projectModel);
        }

        // PUT: api/Project/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProjectModel(int id, ProjectModel projectModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectModel.ProjectId)
            {
                return BadRequest();
            }

            db.Entry(projectModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectModelExists(id))
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

        // POST: api/Project
        [ResponseType(typeof(ProjectModel))]
        public IHttpActionResult PostProjectModel(ProjectModel projectModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProjectModels.Add(projectModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = projectModel.ProjectId }, projectModel);
        }

        // DELETE: api/Project/5
        [ResponseType(typeof(ProjectModel))]
        public IHttpActionResult DeleteProjectModel(int id)
        {
            ProjectModel projectModel = db.ProjectModels.Find(id);
            if (projectModel == null)
            {
                return NotFound();
            }

            db.ProjectModels.Remove(projectModel);
            db.SaveChanges();

            return Ok(projectModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectModelExists(int id)
        {
            return db.ProjectModels.Count(e => e.ProjectId == id) > 0;
        }
    }
}