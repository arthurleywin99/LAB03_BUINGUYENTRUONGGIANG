﻿using System.Web;
using System.Web.Mvc;

namespace Lab03_BuiNguyenTruongGiang
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
