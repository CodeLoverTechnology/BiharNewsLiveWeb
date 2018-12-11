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
    public class M_NewsCategoryMasterController : Controller
    {
        private BiharNewsLiveDBEntities db = new BiharNewsLiveDBEntities();

        // GET: M_NewsCategoryMaster
        public async Task<ActionResult> Index()
        {
            return View(await db.M_NewsCategoryMaster.ToListAsync());
        }

        // GET: M_NewsCategoryMaster/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_NewsCategoryMaster m_NewsCategoryMaster = await db.M_NewsCategoryMaster.FindAsync(id);
            if (m_NewsCategoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_NewsCategoryMaster);
        }

        // GET: M_NewsCategoryMaster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: M_NewsCategoryMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NewsCategoryID,CategoryName,CategoryDesc,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active")] M_NewsCategoryMaster m_NewsCategoryMaster)
        {
            if (ModelState.IsValid)
            {
                db.M_NewsCategoryMaster.Add(m_NewsCategoryMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(m_NewsCategoryMaster);
        }

        // GET: M_NewsCategoryMaster/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_NewsCategoryMaster m_NewsCategoryMaster = await db.M_NewsCategoryMaster.FindAsync(id);
            if (m_NewsCategoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_NewsCategoryMaster);
        }

        // POST: M_NewsCategoryMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "NewsCategoryID,CategoryName,CategoryDesc,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active")] M_NewsCategoryMaster m_NewsCategoryMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m_NewsCategoryMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(m_NewsCategoryMaster);
        }

        // GET: M_NewsCategoryMaster/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_NewsCategoryMaster m_NewsCategoryMaster = await db.M_NewsCategoryMaster.FindAsync(id);
            if (m_NewsCategoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_NewsCategoryMaster);
        }

        // POST: M_NewsCategoryMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M_NewsCategoryMaster m_NewsCategoryMaster = await db.M_NewsCategoryMaster.FindAsync(id);
            db.M_NewsCategoryMaster.Remove(m_NewsCategoryMaster);
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
