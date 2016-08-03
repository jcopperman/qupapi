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
    public class FileResultsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/FileResults
        public IQueryable<FileResult> GetFileResults()
        {
            return db.FileResults;
        }

        // GET: api/FileResults/5
        [ResponseType(typeof(FileResult))]
        public IHttpActionResult GetFileResult(int id)
        {
            FileResult fileResult = db.FileResults.Find(id);
            if (fileResult == null)
            {
                return NotFound();
            }

            return Ok(fileResult);
        }

        // PUT: api/FileResults/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFileResult(int id, FileResult fileResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fileResult.FileId)
            {
                return BadRequest();
            }

            db.Entry(fileResult).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FileResultExists(id))
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

        // POST: api/FileResults
        [ResponseType(typeof(FileResult))]
        public IHttpActionResult PostFileResult(FileResult fileResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FileResults.Add(fileResult);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fileResult.FileId }, fileResult);
        }

        // DELETE: api/FileResults/5
        [ResponseType(typeof(FileResult))]
        public IHttpActionResult DeleteFileResult(int id)
        {
            FileResult fileResult = db.FileResults.Find(id);
            if (fileResult == null)
            {
                return NotFound();
            }

            db.FileResults.Remove(fileResult);
            db.SaveChanges();

            return Ok(fileResult);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FileResultExists(int id)
        {
            return db.FileResults.Count(e => e.FileId == id) > 0;
        }
    }
}