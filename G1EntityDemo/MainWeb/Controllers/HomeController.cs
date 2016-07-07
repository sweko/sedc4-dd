using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new ScifiContext();

            var heinlein = context.Authors.Single(a => a.ID == 92);

            Console.WriteLine(heinlein);
            foreach (var novel in heinlein.Novels)
            {
                Console.WriteLine($"    {novel}");
            }

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