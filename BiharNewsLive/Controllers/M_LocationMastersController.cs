using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BiharNewsLive.ModelsWithDb;

namespace BiharNewsLive.Controllers
{
    public class M_LocationMastersController : Controller
    {
        private BiharNewsLiveDBEntities db = new BiharNewsLiveDBEntities();

        // GET: M_LocationMasters
        public async Task<ActionResult> Index()
        {
            var m_LocationMasters = db.M_LocationMasters.Include(m => m.M_MasterTables);
            return View(await m_LocationMasters.ToListAsync());
        }

        // GET: M_LocationMasters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_LocationMasters m_LocationMasters = await db.M_LocationMasters.FindAsync(id);
            if (m_LocationMasters == null)
            {
                return HttpNotFound();
            }
            return View(m_LocationMasters);
        }

        // GET: M_LocationMasters/Create
        public ActionResult Create()
        {
            ViewBag.CountryID = new SelectList(db.M_MasterTables, "MasterID", "MasterValue");
            return View();
        }

        // POST: M_LocationMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "LocationID,CountryID,State,Division,Districts,Blocks,City,Remarks,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active")] M_LocationMasters m_LocationMasters)
        {
            if (ModelState.IsValid)
            {
                db.M_LocationMasters.Add(m_LocationMasters);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CountryID = new SelectList(db.M_MasterTables, "MasterID", "MasterValue", m_LocationMasters.CountryID);
            return View(m_LocationMasters);
        }

        // GET: M_LocationMasters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_LocationMasters m_LocationMasters = await db.M_LocationMasters.FindAsync(id);
            if (m_LocationMasters == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryID = new SelectList(db.M_MasterTables, "MasterID", "MasterValue", m_LocationMasters.CountryID);
            return View(m_LocationMasters);
        }

        // POST: M_LocationMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "LocationID,CountryID,State,Division,Districts,Blocks,City,Remarks,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active")] M_LocationMasters m_LocationMasters)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m_LocationMasters).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CountryID = new SelectList(db.M_MasterTables, "MasterID", "MasterValue", m_LocationMasters.CountryID);
            return View(m_LocationMasters);
        }

        // GET: M_LocationMasters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_LocationMasters m_LocationMasters = await db.M_LocationMasters.FindAsync(id);
            if (m_LocationMasters == null)
            {
                return HttpNotFound();
            }
            return View(m_LocationMasters);
        }

        // POST: M_LocationMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M_LocationMasters m_LocationMasters = await db.M_LocationMasters.FindAsync(id);
            db.M_LocationMasters.Remove(m_LocationMasters);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
