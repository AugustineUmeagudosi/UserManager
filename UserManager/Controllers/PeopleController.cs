using UserManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserManager.Controllers
{
    public class PeopleController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: People
        public ActionResult Index()
        {
            return View();
        }


        //get a list of people from the db in a json format
        public ActionResult GetPeople()
        {
            var people = _db.Peoples.ToList();
            return Json(new { data = people }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPeoplePartial()
        {
            var people = new People();
            return PartialView("_CreateOrUpdatePeoplePartial", people);
        }

        //save changes to db
        public ActionResult CreateOrUpdatePeople(People people)
        {
            if (ModelState.IsValid)
            {
                _db.Peoples.Add(people);
                _db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}