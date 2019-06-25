using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WisdomPrototype.Models;

namespace WisdomPrototype.Controllers
{
    public class WisdomController : Controller
    {
        private WisdomContext _db = new WisdomContext();
        //Create general
        //GET: Wisdom/create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(_db.AuthorSet.ToList(), "AuthorId", "FullName");
            return View();
        }
        //Create confirm
        //POST: Wisdom/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public ActionResult Create(Wisdom wisdomToAdd)
        {
            if (ModelState.IsValid)
            {
                _db.WisdomSet.Add(wisdomToAdd);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wisdomToAdd);
        }

        //Read general
        // GET: Wisdom
        public ActionResult Index()
        {
            return View(_db.WisdomSet.ToList());
        }

        //Read detail
        //GET: Wisdom/{id}
        [ActionName("Details")]
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wisdom wisdomToRead = _db.WisdomSet.Find(id);
            if (wisdomToRead == null)
            {
                return HttpNotFound();
            }
            return View(wisdomToRead);
        }

        //Update general
        //GET: Wisdom/Update/{id}
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wisdom wisdomToEdit = _db.WisdomSet.Find(id);
            if (wisdomToEdit == null)
            {
                return HttpNotFound();
            }
            return View(wisdomToEdit);
        }
        //Update confirm
        //POST: Wisdom/Update/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public ActionResult Edit(Wisdom wisdomToEdit)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(wisdomToEdit).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wisdomToEdit);
        }
        //Delete general
        //GET: Wisdom/Delete/{id}
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wisdom wisdomToRemove = _db.WisdomSet.Find(id);
            if (wisdomToRemove == null)
            {
                return HttpNotFound();
            }
            return View(wisdomToRemove);
        }
        //Delete confirm
        //POST: Wisdom/Delete/{id}
        public ActionResult Delete(Wisdom wisdomToRemove)
        {
            _db.WisdomSet.Remove(wisdomToRemove);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}