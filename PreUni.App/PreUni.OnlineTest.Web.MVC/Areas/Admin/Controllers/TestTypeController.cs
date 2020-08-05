using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using PreUni.Core.Model;
using PreUni.OnlineTest.DAL.EntityFramework;
using PreUni.OnlineTest.Web.MVC.CustomAttribute;

namespace PreUni.OnlineTest.Web.MVC.Areas.Admin.Controllers
{
    [CustomAuthorize("Developer,Admin")]
    public class TestTypeController : Controller
    {
        private PreUniDbContext db = new PreUniDbContext();

        // GET: Admin/TestType
        public async Task<ActionResult> Index()
        {
            return View(await db.TestTypes.ToListAsync());
        }

        // GET: Admin/TestType/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestType testType = await db.TestTypes.FindAsync(id);
            if (testType == null)
            {
                return HttpNotFound();
            }
            return View(testType);
        }

        // GET: Admin/TestType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TestType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TestTypeID,TestTypeName")] TestType testType)
        {
            if (ModelState.IsValid)
            {
                db.TestTypes.Add(testType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(testType);
        }

        // GET: Admin/TestType/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestType testType = await db.TestTypes.FindAsync(id);
            if (testType == null)
            {
                return HttpNotFound();
            }
            return View(testType);
        }

        // POST: Admin/TestType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TestTypeID,TestTypeName")] TestType testType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(testType);
        }

        // GET: Admin/TestType/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestType testType = await db.TestTypes.FindAsync(id);
            if (testType == null)
            {
                return HttpNotFound();
            }
            return View(testType);
        }

        // POST: Admin/TestType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TestType testType = await db.TestTypes.FindAsync(id);
            db.TestTypes.Remove(testType);
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
