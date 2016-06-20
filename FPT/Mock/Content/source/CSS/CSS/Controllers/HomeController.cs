using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSS.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// UC1: Homepage of RFO
        /// </summary>
        /// <param name="error">error code if user failed in login</param>
        /// <returns>Homepage screen</returns>
        public ActionResult Index(int error = 0)
        {
            // check error code and send error message to view
            switch (error)
            { 
                case 1:
                    ViewBag.errorMessage = "The user name or password provided is incorrect.";
                    break;
                case 2:
                    ViewBag.errorMessage = "User name and password can not be empty";
                    break;
                default:
                    ViewBag.errorMessage = null;
                    break;
            }
            return View();
        }
    }
}
