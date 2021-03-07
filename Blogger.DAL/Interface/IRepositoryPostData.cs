using Blogger.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.DAL.Interface
{
    public interface IRepositoryPostData
    {
        public abstract void AddPost(Post p);
        public abstract List<Post> GetAllPostByUser(string id);
        public abstract void DeletePostById(string id);

    }
}
