using BigSchool.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Migrations;

namespace BigSchool.Controllers
{
    public class CourseController : Controller
    {
        BigSchoolContext db = new BigSchoolContext();
        // GET: Course
        public ActionResult Create()
        {
            Course objCourse = new Course();
            objCourse.ListCategory = db.Categories.ToList();
            return View(objCourse);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course objCourse)
        {
            ModelState.Remove("LecturerId");
            if (!ModelState.IsValid)
            {
                objCourse.ListCategory = db.Categories.ToList();
                return View("Create", objCourse);
            }
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            objCourse.LecturerId = user.Id;
            db.Courses.Add(objCourse);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}