using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecondHand.BLL;
using SecondHand.Model;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {

        public ViewResult Index()
        {
            ViewBag.aaa = "个梵蒂冈的郭德纲";
            ViewBag.modeList = new UsersModel
            {
                UserID = 1,
                LoginCode = "2"
            };
            AllGoods allGoods = new AllGoods();
            var list = allGoods.GetAllList();
            return View();
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