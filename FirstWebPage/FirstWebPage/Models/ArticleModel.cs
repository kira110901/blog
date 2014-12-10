using FirstWebPage.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace FirstWebPage.Models
{
    public class ArticleModel
    {

        public ArticleModel()
        {
         //   Title = "Это заголовок";
         //   Body = "<p>Это обычный текст поста</p>";
          //  Date = DateTime.Now;
          //  Likes = new Collection<LikeModel>();
           
          
        }
        public ICollection<string> Comments
        {
            get { return CommentsRepository.Comments; }

        }

        public AddCommentModel NewComment { get; set; }



        //public string Title { get; set; }
        //public string Body { get; set; }
     //   public DateTime Date { get; set; }

        //public virtual ICollection<LikeModel> Likes { get; set; } //виртуальная чтобы не выгружать это сразу,а только когда обратишься(не забивать память)
      //  public virtual ICollection<CommentItemModel> Comments { get; set; }
    }
}