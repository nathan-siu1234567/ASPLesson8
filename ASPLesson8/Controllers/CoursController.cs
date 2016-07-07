using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPLesson8.Models;

namespace ASPLesson8.Controllers
{
    public class CoursController : Controller
    {
        private ContosoModel db = new ContosoModel();

        // GET: Cours
        public async Task<ActionResult> Index()
        {
            var courses = db.Courses.Include(c => c.Department).Include(c => c.Department1);
            return View(await courses.ToListAsync());
        }

        // GET: Cours/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = await db.Courses.FindAsync(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            return View(cours);
        }

        // GET: Cours/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name");
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name");
            return View();
        }

        // POST: Cours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CourseID,Title,Credits,DepartmentID")] Cours cours)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(cours);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", cours.DepartmentID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", cours.DepartmentID);
            return View(cours);
        }

        // GET: Cours/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = await db.Courses.FindAsync(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", cours.DepartmentID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", cours.DepartmentID);
            return View(cours);
        }

        // POST: Cours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CourseID,Title,Credits,DepartmentID")] Cours cours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cours).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", cours.DepartmentID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", cours.DepartmentID);
            return View(cours);
        }

        // GET: Cours/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = await db.Courses.FindAsync(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            return View(cours);
        }

        // POST: Cours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cours cours = await db.Courses.FindAsync(id);
            db.Courses.Remove(cours);
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
