using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainerList.Models;

namespace TrainerList.Controllers
{
    public class EventController : Controller
    {
        //
        // GET: /Event/

        public ActionResult Index()
        {

            EventModel events = new EventModel();

            return View(events.upcoming(Functions.loggedUser.get_id()));
        }

        //
        // GET: /Event/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Event/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Event/Create

        [HttpPost]
        public ActionResult Create(EventModel  Event)
        {
            try
            {
                // TODO: Add insert logic here
                Event.eventNew(Functions.loggedUser.get_id());


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Event/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Event/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, EventModel Event)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Event/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Event/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
