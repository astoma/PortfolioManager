using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioManager.Controllers
{
    public class SharedController : Controller
    {
        // GET: Shared

        public ActionResult AutoRedirect(int type)
        {
            switch (type)
            {
                case 1: 
                    ViewBag.Message = "Invalid Form Data.";
                    break;
                case 2:
                    ViewBag.Message = "Your password is invalid.";
                    break;
                case 3:
                    ViewBag.Message = "OOOOOOOps!! (T_T) NETWORK Error, can not connect to DB.";
                    break;
            }
            return View();
        }
    }
}