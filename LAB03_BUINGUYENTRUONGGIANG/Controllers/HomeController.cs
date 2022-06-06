using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using LAB03_BUINGUYENTRUONGGIANG.Models;

namespace LAB03_BUINGUYENTRUONGGIANG.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                List<Course> upcommingCourses = context.Courses
                    .Include(prop => prop.Lecturer)
                    .Include(prop => prop.Category)
                    .Where(prop => prop.DateTime > DateTime.Now).ToList();
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