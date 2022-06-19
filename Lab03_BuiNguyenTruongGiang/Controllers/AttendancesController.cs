using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab03_BuiNguyenTruongGiang.DTOs;
using Lab03_BuiNguyenTruongGiang.Models;
using Microsoft.AspNet.Identity;

namespace Lab03_BuiNguyenTruongGiang.Controllers
{
    [RoutePrefix("api/attendances")]
    public class AttendancesController : ApiController
    {
        [HttpPost]
        [Route("goingattend")]
        public IHttpActionResult GoingAttend(AttendanceDto attendanceDto)
        {
            using (var context = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();
                if (context.Attendances.Any(p => p.AttendeeId == userId && p.CourseId == attendanceDto.CourseId))
                {
                    return BadRequest("The Attendance already exist!");
                }
                else
                {
                    Attendance attendance = new Attendance
                    {
                        CourseId = attendanceDto.CourseId,
                        AttendeeId = userId
                    };
                    context.Attendances.Add(attendance);
                    context.SaveChanges();
                    return Ok();
                }
            }
        }

        [HttpPost]
        [Route("goattend")]
        public IHttpActionResult GoAttend(AttendanceDto attendanceDto)
        {
            using (var context = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();
                Attendance attendance = context.Attendances.FirstOrDefault(p => p.CourseId == attendanceDto.CourseId && p.AttendeeId == userId);
                if (attendance == null)
                {
                    return BadRequest("The Attendance doestnot exist!");
                }
                else
                {
                    context.Attendances.Remove(attendance);
                    context.SaveChanges();
                    return Ok();
                }
            }
        }
    }
}
