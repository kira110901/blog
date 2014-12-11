using Database.Models;
using FirstWebPage.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FirstWebPage.Repository
{
    public class NewDataReaders
    {
        public ArticleModel GetArticleModel(string title)
        {
            PostModel postModel = null;
            Collection<string> comments = null;
            using( var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))   //для закрытия соединения(try,catch,finaly)
            {
                connection.Open();
                using( var command = new SqlCommand("SELECT * FROM Post WHERE title = @title"))
                {
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("title",title));
                    using(var reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            postModel = new PostModel(
                                reader["title"].ToString(),
                                reader["body"].ToString(),
                                DateTime.Parse(reader["datecreated"].ToString())
                                );
                        }
                    }
                }


                using (var command = new SqlCommand("SELECT comment.body FROM Comment INNER JOIN Post ON Comment.PostID = Post.PostID WHERE Post.Title = @title"))
                {
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("title", title));
                    comments = new Collection<string>();
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            comments.Add(dataReader["body"].ToString());
                        }
                    }
                }

            }

            return new ArticleModel(postModel,comments);

        }



//==================================================
        public void AddComment(string title, string comment)
        {
            using( var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                 using (var sqlCommand = new SqlCommand(@"INSERT INTO Comments
	                 SELECT id_post, @comment AS MyPost 
                     FROM Post 
                     WHERE title = @title")) 
                {
                     sqlCommand.Parameters.Add(new SqlParameter("comment", comment));
                     sqlCommand.Parameters.Add(new SqlParameter("title", title));
                     sqlCommand.Connection = sqlConnection;
                     sqlCommand.ExecuteNonQuery();
                }
            }
        }

//==================================================
            
    }
}