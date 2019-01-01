using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShowTime.Models;

namespace ShowTime.Controllers
{
    public class MoviesController : Controller
    {
        private Moviecontext db = new Moviecontext();

        // GET: Movies
        public ActionResult Index()
        {
            if ((string)Session["username"] != "rpp")
            {
                Session["flag"] = "You are not allowed";
                return Redirect("/Home/Index");
            }
            var movies = db.Movies.Include(m => m.theatre);
            return View(movies.ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.Thea_id = new SelectList(db.Theatres, "Theatre_id", "Theatre_name");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Movie_id,Movie_name,Show_time,Thea_id")] Movie movie)
        {
            if (ModelState.IsValid)
            {

                db.Movies.Add(movie);
                db.SaveChanges();
               // var count = (from k in db.Seats
                //             select k).Count();
                int costf = 1;
                for (int i=1;i<101;i++)
                {
                    if (i<31)
                    {
                        costf = 100;
                    }
                    else if(i<71)
                    {
                        costf = 200;
                    }
                    else
                    {
                        costf = 300;
                    }
                    Seat myseat = new Seat()
                    {
                        Seat_id = i,
                        Seat_state = false,
                        Seat_cost = costf,
                        Movie_id = movie.Movie_id,
                        Thea_id = movie.Thea_id,
                     };
                    db.Seats.Add(myseat);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Thea_id = new SelectList(db.Theatres, "Theatre_id", "Theatre_name", movie.Thea_id);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.Thea_id = new SelectList(db.Theatres, "Theatre_id", "Theatre_name", movie.Thea_id);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Movie_id,Movie_name,Show_time,Thea_id")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Thea_id = new SelectList(db.Theatres, "Theatre_id", "Theatre_name", movie.Thea_id);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
