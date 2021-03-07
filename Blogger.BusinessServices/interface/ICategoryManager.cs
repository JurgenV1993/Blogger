using Blogger.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.BusinessServices.Interface
{
    public interface ICategoryManager
     {
       public List<Category> GetAllCategories();
    }
}
