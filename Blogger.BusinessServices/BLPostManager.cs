using Blogger.BusinessServices.Interface;
using Blogger.DAL.Interface;
using Blogger.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.BusinessServices
{
    public class BLPostManager : IPostManager
    {
        public IRepositoryPostData repositoryPost;
        public BLPostManager(IRepositoryPostData repositoryPost)
        {
            this.repositoryPost = repositoryPost;
        }
        public void AddNewPost(Post post)
        {
            repositoryPost.AddNewPost(post);
        }

        public void AddNewPostPhoto(Image image)
        {
            repositoryPost.AddNewPostPhoto(image);
        }

        public void DeletePost(string id)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAllPostByUser(string id)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAllPost()
        {
           return  repositoryPost.GetAllPost();
        }
    }
}
