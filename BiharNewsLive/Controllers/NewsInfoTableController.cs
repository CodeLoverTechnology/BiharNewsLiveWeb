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
    public class NewsInfoTableController : ApiController
    {
        private BiharNewsLiveDBEntities db = new BiharNewsLiveDBEntities();

        // GET: api/NewsInfoTable
        public IHttpActionResult GetT_NewsInfoTable()
        {
            IList<NewsModel> ObjNewsModelList = new List<NewsModel>();
            var NewsCollection = from s in db.T_NewsInfoTable.OrderByDescending(x => x.ModifiedDate).Take(20) select s;
            foreach(var news in NewsCollection)
            {
                ObjNewsModelList.Add(new NewsModel() {
                    NewsID=news.NewsID,
                    NewsTypeID = news.NewsType,
                    NewsTypeName= news.M_MasterTables.MasterValue,
                    NewsTitle = news.NewsTitle,
                    HeadLine = news.HeadLine,
                    NewsCategoryID = news.NewsSubCategoryID,
                    NewsSubCategoryID =news.NewsSubCategoryID,
                    NewsCategoryName=news.M_NewsSubCategoryMaster.M_NewsCategoryMaster.CategoryName,
                    NewsSubCategoryName = news.M_NewsSubCategoryMaster.SubNewsCategory,
                    HeadlineImagePath = news.HeadlineImagePath,
                    Location = news.Location,
                    NoOfView = news.NoOfView,
                    NewsDescription = news.NewsDescription,
                    Remarks = news.Remarks,
                    Images1= news.Images1,
                    Images2=news.Images2,
                    Images3=news.Images3,
                    Images4 = news.Images4,
                    Images5= news.Images5,
                    CreatedBy= news.CreatedBy,
                    CreatedDate= news.CreatedDate,
                    ModifiedDate= news.ModifiedDate,
                    ModifiedBy=news.ModifiedBy,
                    Active=news.Active

                });
            }
            return Ok(ObjNewsModelList);
        }

        // GET: api/NewsInfoTable/5
        [ResponseType(typeof(T_NewsInfoTable))]
        public async Task<IHttpActionResult> GetT_NewsInfoTable(int id)
        {
            T_NewsInfoTable t_NewsInfoTable = await db.T_NewsInfoTable.FindAsync(id);
            if (t_NewsInfoTable == null)
            {
                return NotFound();
            }

            return Ok(t_NewsInfoTable);
        }

        // PUT: api/NewsInfoTable/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutT_NewsInfoTable(int id, T_NewsInfoTable t_NewsInfoTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != t_NewsInfoTable.NewsID)
            {
                return BadRequest();
            }

            db.Entry(t_NewsInfoTable).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!T_NewsInfoTableExists(id))
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

        // POST: api/NewsInfoTable
        [ResponseType(typeof(T_NewsInfoTable))]
        public async Task<IHttpActionResult> PostT_NewsInfoTable(T_NewsInfoTable t_NewsInfoTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.T_NewsInfoTable.Add(t_NewsInfoTable);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = t_NewsInfoTable.NewsID }, t_NewsInfoTable);
        }

        // DELETE: api/NewsInfoTable/5
        [ResponseType(typeof(T_NewsInfoTable))]
        public async Task<IHttpActionResult> DeleteT_NewsInfoTable(int id)
        {
            T_NewsInfoTable t_NewsInfoTable = await db.T_NewsInfoTable.FindAsync(id);
            if (t_NewsInfoTable == null)
            {
                return NotFound();
            }

            db.T_NewsInfoTable.Remove(t_NewsInfoTable);
            await db.SaveChangesAsync();

            return Ok(t_NewsInfoTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool T_NewsInfoTableExists(int id)
        {
            return db.T_NewsInfoTable.Count(e => e.NewsID == id) > 0;
        }
    }
}