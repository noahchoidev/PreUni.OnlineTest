using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PreUni.Core.Model;
using PreUni.OnlineTest.DAL.EntityFramework;
using PreUni.OnlineTest.Web.MVC.CustomAttribute;

namespace PreUni.OnlineTest.Web.MVC.Areas.Admin.Controllers
{
    [CustomAuthorize("Developer,Admin")]
    public class ExamSubjectsController : Controller
    {
        private PreUniDbContext db = new PreUniDbContext();

        // GET: Admin/ExamSubjects
        public ActionResult Index()
        {
            var examSubjects = db.ExamSubjects.Include(e => e.Exam).Include(e => e.Subject);
            return View(examSubjects.ToList());
        }

        // GET: Admin/ExamSubjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ExamSubject examSubject = db.ExamSubjects.Find(id);

            if (examSubject == null)
            {
                return HttpNotFound();
            }

            return View(examSubject);
        }

        // GET: Admin/ExamSubjects/Create
        public ActionResult Create()
        {
            var examCnt = db.Exams.Count();
            var subje3ctCnt = db.Subjects.Count();

            ViewBag.ExamID = new SelectList(db.Exams.Include(tt => tt.TestTerm).Include(ty=>ty.TestType), "ExamID", "ExamID");
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName");

            return View();
        }

        // POST: Admin/ExamSubjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExamSubjectID,ExamID,SubjectID,TestDuration,EditedAt,CreatedAt,DeletedAt")] ExamSubject examSubject)
        {
            if (ModelState.IsValid)
            {
                db.ExamSubjects.Add(examSubject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExamID = new SelectList(db.Exams, "ExamID", "Year", examSubject.ExamID);
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", examSubject.SubjectID);
            return View(examSubject);
        }

        // GET: Admin/ExamSubjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamSubject examSubject = db.ExamSubjects.Find(id);
            if (examSubject == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExamID = new SelectList(db.Exams, "ExamID", "Year", examSubject.ExamID);
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", examSubject.SubjectID);
            return View(examSubject);
        }

        // POST: Admin/ExamSubjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExamSubjectID,ExamID,SubjectID,TestDuration,EditedAt,CreatedAt,DeletedAt")] ExamSubject examSubject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examSubject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExamID = new SelectList(db.Exams, "ExamID", "Year", examSubject.ExamID);
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", examSubject.SubjectID);
            return View(examSubject);
        }

        // GET: Admin/ExamSubjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamSubject examSubject = db.ExamSubjects.Find(id);
            if (examSubject == null)
            {
                return HttpNotFound();
            }
            return View(examSubject);
        }

        // POST: Admin/ExamSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExamSubject examSubject = db.ExamSubjects.Find(id);
            db.ExamSubjects.Remove(examSubject);
            db.SaveChanges();
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
