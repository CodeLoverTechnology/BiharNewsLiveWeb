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
    public class T_NewsInfoTableController : Controller
    {
        private BiharNewsLiveDBEntities db = new BiharNewsLiveDBEntities();

        // GET: T_NewsInfoTable
        public async Task<ActionResult> Index()
        {
            var t_NewsInfoTable = db.T_NewsInfoTable.Include(t => t.M_MasterTables).Include(t => t.M_NewsSubCategoryMaster);
            return View(await t_NewsInfoTable.ToListAsync());
        }

        // GET: T_NewsInfoTable/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_NewsInfoTable t_NewsInfoTable = await db.T_NewsInfoTable.FindAsync(id);
            if (t_NewsInfoTable == null)
            {
                return HttpNotFound();
            }
            return View(t_NewsInfoTable);
        }

        // GET: T_NewsInfoTable/Create
        public ActionResult Create()
        {
            ViewBag.NewsType = new SelectList(db.M_MasterTables, "MasterID", "MasterValue");
            ViewBag.NewsSubCategoryID = new SelectList(db.M_NewsSubCategoryMaster, "SubCategoryID", "SubNewsCategory");
            return View();
        }

        // POST: T_NewsInfoTable/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NewsID,NewsType,NewsSubCategoryID,NewsTitle,HeadlineImagePath,HeadLine,NewsDescription,Images1,Images2,Images3,Images4,Images5,Location,NoOfView,Remarks,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active")] T_NewsInfoTable t_NewsInfoTable)
        {
            if (ModelState.IsValid)
            {
                db.T_NewsInfoTable.Add(t_NewsInfoTable);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.NewsType = new SelectList(db.M_MasterTables, "MasterID", "MasterValue", t_NewsInfoTable.NewsType);
            ViewBag.NewsSubCategoryID = new SelectList(db.M_NewsSubCategoryMaster, "SubCategoryID", "SubNewsCategory", t_NewsInfoTable.NewsSubCategoryID);
            return View(t_NewsInfoTable);
        }

        // GET: T_NewsInfoTable/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_NewsInfoTable t_NewsInfoTable = await db.T_NewsInfoTable.FindAsync(id);
            if (t_NewsInfoTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.NewsType = new SelectList(db.M_MasterTables, "MasterID", "MasterValue", t_NewsInfoTable.NewsType);
            ViewBag.NewsSubCategoryID = new SelectList(db.M_NewsSubCategoryMaster, "SubCategoryID", "SubNewsCategory", t_NewsInfoTable.NewsSubCategoryID);
            return View(t_NewsInfoTable);
        }

        // POST: T_NewsInfoTable/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "NewsID,NewsType,NewsSubCategoryID,NewsTitle,HeadlineImagePath,HeadLine,NewsDescription,Images1,Images2,Images3,Images4,Images5,Location,NoOfView,Remarks,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active")] T_NewsInfoTable t_NewsInfoTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_NewsInfoTable).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.NewsType = new SelectList(db.M_MasterTables, "MasterID", "MasterValue", t_NewsInfoTable.NewsType);
            ViewBag.NewsSubCategoryID = new SelectList(db.M_NewsSubCategoryMaster, "SubCategoryID", "SubNewsCategory", t_NewsInfoTable.NewsSubCategoryID);
            return View(t_NewsInfoTable);
        }

        // GET: T_NewsInfoTable/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_NewsInfoTable t_NewsInfoTable = await db.T_NewsInfoTable.FindAsync(id);
            if (t_NewsInfoTable == null)
            {
                return HttpNotFound();
            }
            return View(t_NewsInfoTable);
        }

        // POST: T_NewsInfoTable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            T_NewsInfoTable t_NewsInfoTable = await db.T_NewsInfoTable.FindAsync(id);
            db.T_NewsInfoTable.Remove(t_NewsInfoTable);
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
