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
        public ActionResult Index(string title)
        {
            //string query = Request.QueryString["foo"];
            if (title == null)
            {
                title = "О дрессировке кошек";
            }
            var readers = new NewDataReaders();//считываем из базы
            return View(readers.GetArticleModel(title));
        }

        [HttpPost]
        //[ValidateInput(false)] чтобы можо было отправить код из полей ввода
        public ActionResult Index(ArticleModel model)
        {
            
             var  title = "О дрессировке кошек";
            
            if(model.NewComment != null && ModelState.IsValid)
            {

                var readers = new NewDataReaders();//считываем из базы

                CommentsRepository.Comments.Add(model.NewComment.Commenttext);
                ModelState.Clear(); //чтобы не оставались комментарии при обновлении страницы в поле ввода комментариев
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
