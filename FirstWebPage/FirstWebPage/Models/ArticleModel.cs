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
       
        }
        public ICollection<string> Comments
        {
            get { return CommentsRepository.Comments; }

        }

        public AddCommentModel NewComment { get; set; }

             
        //public virtual ICollection<LikeModel> Likes { get; set; } //виртуальная чтобы не выгружать это сразу,а только когда обратишься(не забивать память)
    
    }
}