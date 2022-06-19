using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                    Categories = context.Categories.ToList(),
                    Heading = "Add Course"
                };
                return View("CourseForm", viewModel);
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

                return RedirectToAction("Mine", "Courses");
            }
        }

        [Authorize]
        public ActionResult Attending()
        {
            using (var context = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();

                List<Course> courses = context.Attendances
                    .Where(p => p.AttendeeId == userId)
                    .Select(p => p.Course)
                    .Include(q => q.Lecturer)
                    .Include(q => q.Category)
                    .ToList();

                List<Following> followings = context.Followings.Where(p => p.FollowerId == userId).ToList();

                List<Attendance> attendances = context.Attendances.Where(p => p.AttendeeId == userId).ToList();

                CoursesViewModel viewModel = new CoursesViewModel
                {
                    UpcommingCourses = courses,
                    ShowAction = User.Identity.IsAuthenticated,
                    FollowingList = followings,
                    AttendanceList = attendances
                };
                return View(viewModel);
            }
        }

        [Authorize]
        public ActionResult Lecturing()
        {
            using (var context = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();

                List<Following> followings = context.Followings
                    .Where(p => p.FollowerId == userId)
                    .Include(p => p.Followee)
                    .ToList();

                return View(followings);
            }
        }

        [Authorize]
        public ActionResult Mine()
        {
            using (var context = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();
                List<Course> mineCourses = context.Courses
                    .Where(p => p.LecturerId == userId && p.DateTime > DateTime.Now && p.IsCanceled == false)
                    .Include(p => p.Lecturer)
                    .Include(p => p.Category)
                    .ToList();

                return View(mineCourses);
            }
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();
                Course course = context.Courses.SingleOrDefault(p => p.Id == id && p.LecturerId == userId);

                CourseViewModel viewModel = new CourseViewModel
                {
                    Categories = context.Categories.ToList(),
                    Date = course.DateTime.ToString("dd/M/yyyy"),
                    Time = course.DateTime.ToString("HH:mm"),
                    Category = course.CategoryId,
                    Place = course.Place,
                    Heading = "Edit Course",
                    Id = course.Id
                };
                return View("CourseForm", viewModel);
            }
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(CourseViewModel viewModel)
        {
            using (var context = new ApplicationDbContext())
            {
                if (!ModelState.IsValid)
                {
                    viewModel.Categories = context.Categories.ToList();
                    return View("Create", viewModel);
                }
                var userId = User.Identity.GetUserId();
                Course course = context.Courses.SingleOrDefault(p => p.Id == viewModel.Id && p.LecturerId == userId);

                course.Place = viewModel.Place;
                course.DateTime = viewModel.GetDateTime();
                course.CategoryId = viewModel.Category;
                context.SaveChanges();

                return RedirectToAction("CourseForm", "Home");
            }
        }
    }
}