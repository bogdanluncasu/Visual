using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeststingDotNet.Models;
using WebGrease.Css.Extensions;

namespace TeststingDotNet.Controllers
{
    public class HomeController : Controller
    {
        private TestDbEntities db = new TestDbEntities();

        //
        // GET: /Home/
        
        public ActionResult Index(string searchby,bool reserved =false)
        {
           
            IQueryable<Booking> bookings;
            var rooms=db.Rooms.Where(x => x.Type == searchby && x.Reserved==reserved || searchby == null).ToList();
            bookings = db.Bookings.Include(b => b.Room);
            ViewModel mymodel = new ViewModel();
            mymodel.Room = rooms;
           
          mymodel.Booking = bookings;
            return View(mymodel);
            
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id = 0)
        {
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            ViewBag.RoomBooking = new SelectList(db.Rooms, "Id", "Id");
            return View();
        }

        //
        // POST: /Home/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Booking booking,int id)
        {
            booking.DateStart = "2 27 11:48 09";
           Room rooms = db.Rooms.Find(id);
            booking.RoomBooking = rooms.Id;
            booking.Id = db.Bookings.Count();
            if (ModelState.IsValid )
            {

                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoomBooking = new SelectList(db.Rooms, "Id", "Type", booking.RoomBooking);
            return View(booking);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoomBooking = new SelectList(db.Rooms, "Id", "Type", booking.RoomBooking);
            return View(booking);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoomBooking = new SelectList(db.Rooms, "Id", "Type", booking.RoomBooking);
            return View(booking);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}