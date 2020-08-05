using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PreUni.Core.Model;
using PreUni.OnlineTest.DAL.EntityFramework;
using PreUni.OnlineTest.Web.MVC.CustomAttribute;

namespace PreUni.OnlineTest.Web.MVC.Areas.Admin.Controllers
{
    [CustomAuthorize("Developer,Admin")]
    public class ExamController : Controller
    {
        private PreUniDbContext db = new PreUniDbContext();

        // GET: Admin/Exam
        public async Task<ActionResult> Index()
        {
            var exams = db.Exams.Include(e => e.TestTerm).Include(e => e.TestType);
            return View(await exams.ToListAsync());
        }

        // GET: Admin/Exam/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = await db.Exams.FindAsync(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: Admin/Exam/Create
        public ActionResult Create()
        {
            ViewBag.TestTermID = new SelectList(db.TestTerms, "TestTermID", "TermName");
            ViewBag.TestTypeID = new SelectList(db.TestTypes, "TestTypeID", "TestTypeName");
            return View();
        }

        // POST: Admin/Exam/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ExamID,Year,ExamDescription,TestTypeID,TestTermID,EditedAt,CreatedAt,DeletedAt")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Exams.Add(exam);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TestTermID = new SelectList(db.TestTerms, "TestTermID", "TermName", exam.TestTermID);
            ViewBag.TestTypeID = new SelectList(db.TestTypes, "TestTypeID", "TestTypeName", exam.TestTypeID);
            return View(exam);
        }

        // GET: Admin/Exam/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = await db.Exams.FindAsync(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            ViewBag.TestTermID = new SelectList(db.TestTerms, "TestTermID", "TermName", exam.TestTermID);
            ViewBag.TestTypeID = new SelectList(db.TestTypes, "TestTypeID", "TestTypeName", exam.TestTypeID);
            return View(exam);
        }

        // POST: Admin/Exam/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ExamID,Year,ExamDescription,TestTypeID,TestTermID,EditedAt,CreatedAt,DeletedAt")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TestTermID = new SelectList(db.TestTerms, "TestTermID", "TermName", exam.TestTermID);
            ViewBag.TestTypeID = new SelectList(db.TestTypes, "TestTypeID", "TestTypeName", exam.TestTypeID);
            return View(exam);
        }

        // GET: Admin/Exam/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = await db.Exams.FindAsync(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Admin/Exam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Exam exam = await db.Exams.FindAsync(id);
            db.Exams.Remove(exam);
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
