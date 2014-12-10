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
       
        [HttpGet]
        public ActionResult Index()
        {
            //string query = Request.QueryString["foo"];
            return View(new ArticleModel());
        }

        [HttpPost]
        //[ValidateInput(false)] чтобы можо было отправить код из полей ввода
        public ActionResult Index(ArticleModel model)
        {
            if(model.NewComment != null && ModelState.IsValid)
            {
                CommentsRepository.Comments.Add(model.NewComment.Commenttext);
                return View(new ArticleModel());
            }
            return View(model);
        }



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
        //[HttpPost] //в этот метод можно зайти только используюя метод post
     //   public ActionResult Index(AddCommentModel model)
      //  {
       //     if (!string.IsNullOrWhiteSpace(model.Commenttext))
       //     {
       //         CommentsRepository.Comments.Add(model.Commenttext);
       //     }
        //    return View(new ArticleModel());
       // }

    }
}
