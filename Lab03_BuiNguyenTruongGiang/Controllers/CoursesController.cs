using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab03_BuiNguyenTruongGiang.Models;
using Lab03_BuiNguyenTruongGiang.ViewModels;
using Microsoft.AspNet.Identity;

namespace Lab03_BuiNguyenTruongGiang.Controllers
{
    public class CoursesController : Controller
    {
        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            using (var context = new ApplicationDbContext())
            {
                CourseViewModel viewModel = new CourseViewModel
                {
                    Categories = context.Categories.ToList()
                };
                return View(viewModel);
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel viewModel)
        {
            using (var context = new ApplicationDbContext())
            {
                if (!ModelState.IsValid)
                {
                    viewModel.Categories = context.Categories.ToList();
                    return View(viewModel);
                }
                Course course = new Course
                {
                    LecturerId = User.Identity.GetUserId(),
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