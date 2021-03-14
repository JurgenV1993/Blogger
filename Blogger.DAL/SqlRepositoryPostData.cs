using Blogger.DAL.Interface;
using Blogger.Models;
using Blogger.POCO;
using System.Collections.Generic;
using System.Linq;

namespace Blogger.DAL
{
    public class SqlRepositoryPostData: IRepositoryPostData
    {
        public readonly BloggerCotext conn; 
        public SqlRepositoryPostData()
        {
            conn = new BloggerCotext();
        }

        public void AddNewPost(Post p)
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
        
        public Post ConvertEntitytoPoco(BL_Post p) 
        {
            Post post = new Post();
            post.Description = p.Description;
            post.Title = p.Title;
            return post;
        }
        public void ConvertPocoToEntity(Post p)
        {
            BL_Post post = new BL_Post();
            post.Description = p.Description;
            post.Title = p.Title;
            post.CategoryID  = 1;
            conn.Add(post);
            conn.SaveChanges();
        }
        public void ConvertPocoToEntity(Image i)
        {
            BL_ImageModel img = new BL_ImageModel();
            img.Title = i.Title;
            img.ImageName  = i.ImageName ;
            img.ImageFile = i.ImageFile;
            conn.Add(img);
            conn.SaveChanges();
        }

        public void AddNewPostPhoto(Image image)
        {
            ConvertPocoToEntity(image);
        }
    }
}
