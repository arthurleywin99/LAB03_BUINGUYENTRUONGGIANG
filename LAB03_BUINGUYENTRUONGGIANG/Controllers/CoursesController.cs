using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LAB03_BUINGUYENTRUONGGIANG.Models;
using LAB03_BUINGUYENTRUONGGIANG.ViewModels;
using Microsoft.AspNet.Identity;

namespace LAB03_BUINGUYENTRUONGGIANG.Controllers
{
    public class CoursesController : Controller
    {
        public CoursesController()
        {
            
        }

        // GET: Courses
        [Authorize]
        public ActionResult Create()
        {
            using (var context = new ApplicationDbContext())
            {
                var viewModel = new CourseViewModel
                {
                    Categories = context.Categories.ToList()
                };
                return View(viewModel);
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(CourseViewModel viewModel)
        {
            using (var context = new ApplicationDbContext())
            {
                if (!ModelState.IsValid)
                {
                    viewModel.Categories = context.Categories.ToList();
                    return View("Create", viewModel);
                }
                var course = new Course
                {
                    LectureId = User.Identity.GetUserId(),
                    DateTime = viewModel.GetDateTime(),
                    CategoryId = viewModel.Category,
                    Place = viewModel.Place
                };
                context.Courses.Add(course);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
        }
    }
}