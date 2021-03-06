using Blogger.DAL.Interface;
using Blogger.Models;
using Blogger.POCO;
using Blogger.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blogger.DAL
{
    public class SqlRepositoryPostData: IRepositoryPostData
    {
        public readonly MyCotext conn; 
        public SqlRepositoryPostData()
        {
            conn = new MyCotext();
        }

        public void AddPost(Post p)
        {
            if (p != null) 
            {
                ConvertPocoToEntity(p);
            }
        }
        public List<Post> GetAllPostByUser(string id)
        {
            List<Post> posts = new List<Post>();
            IQueryable<BL_Post> post = from c in conn.Posts
                                                   select c;

            foreach (var p in post)
            {
              posts.Add(ConvertEntitytoPoco(p));
            }
            return posts;
        }

        public void DeletePostById(string id)
        {
            int key = int.Parse(id);
            IQueryable<BL_Post> post = from c in conn.Posts
                                       where c.ID == key
                                       select c;

            if (post != null) 
            {
                conn.Posts.Remove(post.FirstOrDefault());
            }
        }
        List<Post> IRepositoryPostData.GetAllPostByUser(string id)
        {
            throw new NotImplementedException();
        }
        public Post ConvertEntitytoPoco(BL_Post p) 
        {
            Post post = new Post();
            post.Categories = p.Categories;
            post.Description = p.Description;
            post.Title = p.Title;
            return post;
        }
        public void ConvertPocoToEntity(Post p)
        {
            SqlRepositoryCategoryData sqlRepositoryCategoryData = new SqlRepositoryCategoryData();
            BL_Post post = new BL_Post();
            post.Description = p.Description;
            post.Title = p.Title;
            post.Categories = p.Categories;
        }
    }
}
