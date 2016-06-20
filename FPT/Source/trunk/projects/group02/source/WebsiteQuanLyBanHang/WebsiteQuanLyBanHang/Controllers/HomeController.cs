using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace WebsiteQuanLyBanHang.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Ứng dụng Quản lý bán hàng";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Thông tin liên lạc";

            return View();
        }
    }
}