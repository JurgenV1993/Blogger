using Blogger.POCO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.BusinessServices.Interface
{
    public interface ICategoryManager
    {
        public Category GetCategoryBykey(string key);
        public List<Category> GetAllCategories();
        public IEnumerable<SelectListItem> DropDownCategories();
    }
}
