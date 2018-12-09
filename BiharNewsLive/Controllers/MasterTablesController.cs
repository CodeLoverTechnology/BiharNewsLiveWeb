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
    public class MasterTablesController : Controller
    {
        private BiharNewsLiveDBEntities db = new BiharNewsLiveDBEntities();

        // GET: MasterTables
        public async Task<ActionResult> Index()
        {
            return View(await db.M_MasterTables.ToListAsync());
        }

        // GET: MasterTables/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_MasterTables m_MasterTables = await db.M_MasterTables.FindAsync(id);
            if (m_MasterTables == null)
            {
                return HttpNotFound();
            }
            return View(m_MasterTables);
        }

        // GET: MasterTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MasterID,MasterValue,MasterTable,CreatedDate,ModifiedDate,Active")] M_MasterTables m_MasterTables)
        {
            if (ModelState.IsValid)
            {
                db.M_MasterTables.Add(m_MasterTables);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(m_MasterTables);
        }

        // GET: MasterTables/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_MasterTables m_MasterTables = await db.M_MasterTables.FindAsync(id);
            if (m_MasterTables == null)
            {
                return HttpNotFound();
            }
            return View(m_MasterTables);
        }

        // POST: MasterTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MasterID,MasterValue,MasterTable,CreatedDate,ModifiedDate,Active")] M_MasterTables m_MasterTables)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m_MasterTables).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(m_MasterTables);
        }

        // GET: MasterTables/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_MasterTables m_MasterTables = await db.M_MasterTables.FindAsync(id);
            if (m_MasterTables == null)
            {
                return HttpNotFound();
            }
            return View(m_MasterTables);
        }

        // POST: MasterTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M_MasterTables m_MasterTables = await db.M_MasterTables.FindAsync(id);
            db.M_MasterTables.Remove(m_MasterTables);
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
