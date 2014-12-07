using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstWebPage.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
       
        public ContentResult Index()
        {
            return new ContentResult() { Content = "Зона администрирования"};
        }

    }
}
