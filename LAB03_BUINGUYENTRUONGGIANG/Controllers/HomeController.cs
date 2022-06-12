using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Lab03_BuiNguyenTruongGiang.Models;

namespace Lab03_BuiNguyenTruongGiang.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                List<Course> upcommingCourses = context.Courses
                    .Include(p => p.Lecturer)
                    .Include(p => p.Category)
                    .Where(p => p.DateTime > DateTime.Now).ToList();
                return View(upcommingCourses);
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