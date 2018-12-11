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
    public class M_NewsSubCategoryMasterController : Controller
    {
        private BiharNewsLiveDBEntities db = new BiharNewsLiveDBEntities();

        // GET: M_NewsSubCategoryMaster
        public async Task<ActionResult> Index()
        {
            var m_NewsSubCategoryMaster = db.M_NewsSubCategoryMaster.Include(m => m.M_NewsCategoryMaster);
            return View(await m_NewsSubCategoryMaster.ToListAsync());
        }

        // GET: M_NewsSubCategoryMaster/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_NewsSubCategoryMaster m_NewsSubCategoryMaster = await db.M_NewsSubCategoryMaster.FindAsync(id);
            if (m_NewsSubCategoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_NewsSubCategoryMaster);
        }

        // GET: M_NewsSubCategoryMaster/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.M_NewsCategoryMaster, "NewsCategoryID", "CategoryName");
            return View();
        }

        // POST: M_NewsSubCategoryMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SubCategoryID,CategoryID,SubNewsCategory,SubNewsDesc,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active")] M_NewsSubCategoryMaster m_NewsSubCategoryMaster)
        {
            if (ModelState.IsValid)
            {
                db.M_NewsSubCategoryMaster.Add(m_NewsSubCategoryMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.M_NewsCategoryMaster, "NewsCategoryID", "CategoryName", m_NewsSubCategoryMaster.CategoryID);
            return View(m_NewsSubCategoryMaster);
        }

        // GET: M_NewsSubCategoryMaster/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_NewsSubCategoryMaster m_NewsSubCategoryMaster = await db.M_NewsSubCategoryMaster.FindAsync(id);
            if (m_NewsSubCategoryMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.M_NewsCategoryMaster, "NewsCategoryID", "CategoryName", m_NewsSubCategoryMaster.CategoryID);
            return View(m_NewsSubCategoryMaster);
        }

        // POST: M_NewsSubCategoryMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SubCategoryID,CategoryID,SubNewsCategory,SubNewsDesc,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active")] M_NewsSubCategoryMaster m_NewsSubCategoryMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m_NewsSubCategoryMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.M_NewsCategoryMaster, "NewsCategoryID", "CategoryName", m_NewsSubCategoryMaster.CategoryID);
            return View(m_NewsSubCategoryMaster);
        }

        // GET: M_NewsSubCategoryMaster/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_NewsSubCategoryMaster m_NewsSubCategoryMaster = await db.M_NewsSubCategoryMaster.FindAsync(id);
            if (m_NewsSubCategoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_NewsSubCategoryMaster);
        }

        // POST: M_NewsSubCategoryMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M_NewsSubCategoryMaster m_NewsSubCategoryMaster = await db.M_NewsSubCategoryMaster.FindAsync(id);
            db.M_NewsSubCategoryMaster.Remove(m_NewsSubCategoryMaster);
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
