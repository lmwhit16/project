using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PryorCalendarLogin.Models;

namespace PryorCalendarLogin.Controllers
{
    public class CalEventController : Controller
    {
        private CalendarDBEntities db = new CalendarDBEntities();

        //
        // GET: /CalEvent/

        public ActionResult Index()
        {
            var cal_event = db.Cal_Event.Include(c => c.User);
            return View(cal_event.ToList());
        }

        //
        // GET: /CalEvent/Details/5

        public ActionResult Details(Guid id)
        {
            Cal_Event cal_event = db.Cal_Event.Find(id);
            if (cal_event == null)
            {
                return HttpNotFound();
            }
            return View(cal_event);
        }

        //
        // GET: /CalEvent/Create

        public ActionResult Create()
        {
            ViewBag.User_ID = new SelectList(db.Users, "User_ID", "User_Name");
            return View();
        }

        //
        // POST: /CalEvent/Create

        [HttpPost]
        public ActionResult Create(Cal_Event cal_event)
        {
            if (ModelState.IsValid)
            {
                cal_event.Event_ID = Guid.NewGuid();
                db.Cal_Event.Add(cal_event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User_ID = new SelectList(db.Users, "User_ID", "User_Name", cal_event.User_ID);
            return View(cal_event);
        }

        //
        // GET: /CalEvent/Edit/5

        public ActionResult Edit(Guid id)
        {
            Cal_Event cal_event = db.Cal_Event.Find(id);
            if (cal_event == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_ID = new SelectList(db.Users, "User_ID", "User_Name", cal_event.User_ID);
            return View(cal_event);
        }

        //
        // POST: /CalEvent/Edit/5

        [HttpPost]
        public ActionResult Edit(Cal_Event cal_event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cal_event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User_ID = new SelectList(db.Users, "User_ID", "User_Name", cal_event.User_ID);
            return View(cal_event);
        }

        //
        // GET: /CalEvent/Delete/5

        public ActionResult Delete(Guid id)
        {
            Cal_Event cal_event = db.Cal_Event.Find(id);
            if (cal_event == null)
            {
                return HttpNotFound();
            }
            return View(cal_event);
        }

        //
        // POST: /CalEvent/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Cal_Event cal_event = db.Cal_Event.Find(id);
            db.Cal_Event.Remove(cal_event);
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