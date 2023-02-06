using Shop.commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            var ses = Session[CommonConstants.USER_SESSION];
            if (ses == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}