﻿using System.Web.Mvc;

namespace QuanLyKho.Areas.Sale
{
    public class SaleAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Sale";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Sale_default",
                "Sale/{controller}/{action}/{id}",
                new {controller="", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}