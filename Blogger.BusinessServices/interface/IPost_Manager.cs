using Blogger.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.BusinessServices.Interface
{
    interface IPost_Manager
    {
        public List<Post> GetAllPostByUser(string id);
        public void DeletePost();

    }
}
