using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab03_BuiNguyenTruongGiang.Models;
using Microsoft.AspNet.Identity;

namespace Lab03_BuiNguyenTruongGiang.Controllers.Api
{
    public class CoursesController : ApiController
    {
        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();

                Course course = context.Courses.SingleOrDefault(p => p.Id == id && p.LecturerId == userId);
                if (course.IsCanceled)
                {
                    return NotFound();
                }
                course.IsCanceled = true;
                context.SaveChanges();

                return Ok();
            }
        }
    }
}
