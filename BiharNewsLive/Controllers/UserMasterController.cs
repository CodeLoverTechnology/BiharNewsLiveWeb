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
using BiharNewsLive.ModelsWithDb;

namespace BiharNewsLive.Controllers
{
    public class UserMasterController : ApiController
    {
        private BiharNewsLiveDBEntities db = new BiharNewsLiveDBEntities();

        // GET: api/UserMaster
        public IQueryable<M_UserMaster> GetM_UserMaster()
        {
            return db.M_UserMaster;
        }

        // GET: api/UserMaster/5
        [ResponseType(typeof(M_UserMaster))]
        public async Task<IHttpActionResult> GetM_UserMaster(string id)
        {
            M_UserMaster m_UserMaster = await db.M_UserMaster.FindAsync(id);
            if (m_UserMaster == null)
            {
                return NotFound();
            }

            return Ok(m_UserMaster);
        }

        // PUT: api/UserMaster/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutM_UserMaster(string id, M_UserMaster m_UserMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != m_UserMaster.RegistrationID)
            {
                return BadRequest();
            }

            db.Entry(m_UserMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!M_UserMasterExists(id))
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

        // POST: api/UserMaster
        [ResponseType(typeof(M_UserMaster))]
        public async Task<IHttpActionResult> PostM_UserMaster(M_UserMaster m_UserMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.M_UserMaster.Add(m_UserMaster);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (M_UserMasterExists(m_UserMaster.RegistrationID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = m_UserMaster.RegistrationID }, m_UserMaster);
        }

        // DELETE: api/UserMaster/5
        [ResponseType(typeof(M_UserMaster))]
        public async Task<IHttpActionResult> DeleteM_UserMaster(string id)
        {
            M_UserMaster m_UserMaster = await db.M_UserMaster.FindAsync(id);
            if (m_UserMaster == null)
            {
                return NotFound();
            }

            db.M_UserMaster.Remove(m_UserMaster);
            await db.SaveChangesAsync();

            return Ok(m_UserMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool M_UserMasterExists(string id)
        {
            return db.M_UserMaster.Count(e => e.RegistrationID == id) > 0;
        }
    }
}