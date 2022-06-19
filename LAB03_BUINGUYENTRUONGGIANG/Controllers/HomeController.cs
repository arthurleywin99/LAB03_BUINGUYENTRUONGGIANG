using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Lab03_BuiNguyenTruongGiang.Models;
using Lab03_BuiNguyenTruongGiang.ViewModels;
using Microsoft.AspNet.Identity;

namespace Lab03_BuiNguyenTruongGiang.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();

                List<Course> upcommingCourses = context.Courses
                    .Include(p => p.Lecturer)
                    .Include(p => p.Category)
                    .Where(p => p.DateTime > DateTime.Now && p.IsCanceled == false).ToList();
                
                List<Following> followings = context.Followings.Where(p => p.FollowerId == userId).ToList();

                List<Attendance> attendances = context.Attendances.Where(p => p.AttendeeId == userId).ToList();

                CoursesViewModel viewModel = new CoursesViewModel
                {
                    UpcommingCourses = upcommingCourses,
                    ShowAction = User.Identity.IsAuthenticated,
                    FollowingList = followings,
                    AttendanceList = attendances
                };
                return View(viewModel);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}