using FirstWebPage.Models;
using FirstWebPage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstWebPage.Controllers
{
    public class HomeController : Controller
    {
       // public ActionResult AddComment()
       // {
       //    string comment = Request.Form["commenttext"];
       //    return RedirectToAction("Index","Home");
       // }
 //-------------------------------------------------------------
        // public ActionResult AddComment(string commenttext)
        // {
        //    return RedirectToAction("Index","Home");
        // }
 //-------------------------------------------------------------
       
        //public ActionResult AddComment(AddCommentModel model)
      //  {
      //      return RedirectToAction("index", "home");
      //  }
 //-------------------------------------------------------------
        [HttpGet]
        public ActionResult Index()
        {
            string query = Request.QueryString["foo"];
            var model = new ArticleModel();
            return View(model);
        }
        
        [HttpPost] //в этот метод можно зайти только используюя метод post
        public ActionResult Index(AddCommentModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Commenttext))
            {
                CommentsRepository.Comments.Add(model.Commenttext);
            }
            return View(new ArticleModel());
        }

    }
}
