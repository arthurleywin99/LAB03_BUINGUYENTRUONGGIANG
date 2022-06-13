using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab03_BuiNguyenTruongGiang.Models;

namespace Lab03_BuiNguyenTruongGiang.ViewModels
{
    public class CoursesViewModel
    {
        public IEnumerable<Course> UpcommingCourses { get; set; }
        public bool ShowAction { get; set; }
        public IEnumerable<Following> FollowingList { get; set; }
        public IEnumerable<Attendance> AttendanceList { get; set; }
    }
}