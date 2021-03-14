using Blogger.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.BusinessServices.Interface
{
    public interface IPostManager
    {
        public List<Post> GetAllPostByUser(string id);
        public void DeletePost(string id);
        public void AddNewPost(Post post);
        public void AddNewPostPhoto(Image image);
    }
}
