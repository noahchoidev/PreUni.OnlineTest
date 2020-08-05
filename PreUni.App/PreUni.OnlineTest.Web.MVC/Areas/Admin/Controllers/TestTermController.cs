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
    public class TestTermController : Controller
    {
        private PreUniDbContext db = new PreUniDbContext();

        // GET: Admin/TestTerm
        public async Task<ActionResult> Index()
        {
            return View(await db.TestTerms.ToListAsync());
        }

        // GET: Admin/TestTerm/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestTerm testTerm = await db.TestTerms.FindAsync(id);
            if (testTerm == null)
            {
                return HttpNotFound();
            }
            return View(testTerm);
        }

        // GET: Admin/TestTerm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TestTerm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TestTermID,TermName")] TestTerm testTerm)
        {
            if (ModelState.IsValid)
            {
                db.TestTerms.Add(testTerm);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(testTerm);
        }

        // GET: Admin/TestTerm/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestTerm testTerm = await db.TestTerms.FindAsync(id);
            if (testTerm == null)
            {
                return HttpNotFound();
            }
            return View(testTerm);
        }

        // POST: Admin/TestTerm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TestTermID,TermName")] TestTerm testTerm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testTerm).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(testTerm);
        }

        // GET: Admin/TestTerm/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestTerm testTerm = await db.TestTerms.FindAsync(id);
            if (testTerm == null)
            {
                return HttpNotFound();
            }
            return View(testTerm);
        }

        // POST: Admin/TestTerm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TestTerm testTerm = await db.TestTerms.FindAsync(id);
            db.TestTerms.Remove(testTerm);
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
