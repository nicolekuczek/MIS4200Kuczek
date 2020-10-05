using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MIS4200Kuczek.DAL;
using MIS4200Kuczek.Models;

namespace MIS4200Kuczek.Controllers
{
    public class EnrollsController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: Enrolls
        public ActionResult Index()
        {
            var enrolls = db.enrolls.Include(e => e.course).Include(e => e.student);
            return View(enrolls.ToList());
        }

        // GET: Enrolls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrolls enrolls = db.enrolls.Find(id);
            if (enrolls == null)
            {
                return HttpNotFound();
            }
            return View(enrolls);
        }

        // GET: Enrolls/Create
        public ActionResult Create()
        {
            ViewBag.courseID = new SelectList(db.courses, "courseID", "courseName");
            ViewBag.studentID = new SelectList(db.students, "studentID", "StudentFullName");
            return View();
        }

        // POST: Enrolls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "enrollsID,studentID,courseID,letterGrade")] Enrolls enrolls)
        {
            if (ModelState.IsValid)
            {
                db.enrolls.Add(enrolls);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.courseID = new SelectList(db.courses, "courseID", "courseName", enrolls.courseID);
            ViewBag.studentID = new SelectList(db.students, "studentID", "StudentFullName", enrolls.studentID);
            return View(enrolls);
        }

        // GET: Enrolls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrolls enrolls = db.enrolls.Find(id);
            if (enrolls == null)
            {
                return HttpNotFound();
            }
            ViewBag.courseID = new SelectList(db.courses, "courseID", "courseName", enrolls.courseID);
            ViewBag.studentID = new SelectList(db.students, "studentID", "StudentFullName", enrolls.studentID);
            return View(enrolls);
        }

        // POST: Enrolls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "enrollsID,studentID,courseID,letterGrade")] Enrolls enrolls)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrolls).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.courseID = new SelectList(db.courses, "courseID", "courseName", enrolls.courseID);
            ViewBag.studentID = new SelectList(db.students, "studentID", "StudentFullName", enrolls.studentID);
            return View(enrolls);
        }

        // GET: Enrolls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrolls enrolls = db.enrolls.Find(id);
            if (enrolls == null)
            {
                return HttpNotFound();
            }
            return View(enrolls);
        }

        // POST: Enrolls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enrolls enrolls = db.enrolls.Find(id);
            db.enrolls.Remove(enrolls);
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
