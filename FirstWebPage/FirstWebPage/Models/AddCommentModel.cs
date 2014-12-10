using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstWebPage.Models
{
    public class AddCommentModel 
    {
        public string Commenttext { get; set; }
        public UserModel User { get; set; }
    }   
}
