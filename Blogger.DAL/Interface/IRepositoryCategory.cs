using Blogger.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.DAL.Interface
{
    interface IRepositoryCategory
    {
        public List<Category> GetAllCategories();
    }
}
