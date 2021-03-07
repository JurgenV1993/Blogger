using Blogger.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.BusinessServices.Interface
{
    public interface ICategory_Manager
     {
       public List<Category> GetAllCategories();
    }
}
