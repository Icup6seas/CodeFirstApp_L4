using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirstApp_L4.DAL;
using CodeFirstApp_L4.Models;

namespace CodeFirstApp_L4.Controllers
{
    public class SummaryController : Controller
    {
        private EntertainmentContext db = new EntertainmentContext();

        // GET: Summary
        public ActionResult Index()
        {
            var summaries = db.Summaries.Include(e => e.Movie).Include(e => e.Actor);
            return View(summaries.ToList());
        }

        // GET: Summary/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Summary summary = db.Summaries.Find(id);
            if (summary == null)
            {
                return HttpNotFound();
            }
            return View(summary);
        }

        // GET: Summary/Create
        public ActionResult Create()
        {
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "Title");
            ViewBag.ActorID = new SelectList(db.Actors, "ID", "LastName", "FirstName");
            return View();
        }

        // POST: Summary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SummaryID,MovieID,ActorID,Rating")] Summary summary)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Summaries.Add(summary);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }


            return View(summary);
        }

        // GET: Summary/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Summary summary = db.Summaries.Find(id);
            if (summary == null)
            {
                return HttpNotFound();
            }
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "Title", summary.MovieID);
            ViewBag.ActorID = new SelectList(db.Actors, "ID", "LastName", "FirstName", summary.ActorID);
            return View(summary);
        }

        // POST: Summary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SummaryID,MovieID,ActorID,Rating")] Summary summary)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(summary).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                }

            }
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "Title", summary.MovieID);
            ViewBag.ActorID = new SelectList(db.Actors, "ID", "LastName", "FirstName", summary.ActorID);
            return View(summary);
        }

        // GET: Summary/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete Failed.";
            }
            Summary summary = db.Summaries.Find(id);
            if (summary == null)
            {
                return HttpNotFound();
            }
            return View(summary);
        }

        // POST: Summary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Summary summary = db.Summaries.Find(id);
                db.Summaries.Remove(summary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true});
            }

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
