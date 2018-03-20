using FirstProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace FirstProject.Controllers
{
    public class UsersController : Controller
    {
        PersonContext db = new PersonContext();

        public ActionResult Index(string searchString, int page = 1)
        {
            var people = db.People.AsQueryable();
            int pageSize = 3;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                people = db.People.Where(p => (p.FirstName.ToLower() + p.LastName.ToLower()).Contains(searchString));
            }
            //return View(people.OrderBy(p => p.PersonId).ToPagedList(page, pageSize
            return Request.IsAjaxRequest()
                ? (ActionResult)PartialView("Listing", people.OrderBy(p => p.PersonId).ToPagedList(page, pageSize))
                : View(people.OrderBy(p => p.PersonId).ToPagedList(page, pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(person);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }

            return View(person);
        }

        [HttpPost]
        public ActionResult Edit(Person person)
        {

            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return PartialView(person);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmend(int id)
        {
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            db.People.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Comments(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return PartialView(person);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);

        }
    }
}