using FirstWebPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstWebPage.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            var model = new ArticleModel();
            return View(model);
        }

    }
}
