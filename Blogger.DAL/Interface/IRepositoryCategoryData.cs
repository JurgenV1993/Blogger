using Blogger.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.DAL.Interface
{
    public interface IRepositoryCategoryData
    {
        public List<Category> GetAllCategories();
    }
}
