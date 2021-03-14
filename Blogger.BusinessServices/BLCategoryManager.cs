using Blogger.BusinessServices.Interface;
using Blogger.DAL.Interface;
using Blogger.POCO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Blogger.BusinessServices
{
    public class BLCategoryManager: ICategoryManager
    {
        public readonly IRepositoryCategoryData sqlRepository;
        public BLCategoryManager(IRepositoryCategoryData sqlRepository)
        {
            if (sqlRepository !=null) 
            {
                this.sqlRepository = sqlRepository;
            }
        }
        public List<Category> GetAllCategories()
        {
           var categories= sqlRepository.GetAllCategories();
            return categories;
        }

        public IEnumerable<SelectListItem> DropDownCategories()
        {
            List<SelectListItem> ddc = sqlRepository.GetAllCategories().Select(n => new SelectListItem
            {
                Text = n.CategoryName,// n.ID.ToString(),
                Value = n.ID.ToString()
            }).ToList(); 

            var defaultcategory = new SelectListItem()
            {
                Value = "0",
                Text = "--- select Category ---"
            };
            ddc.Insert(0, defaultcategory);
            return new SelectList(ddc, "Value", "Text");
        }

        public Category GetCategoryBykey(string key)
        {
            var category = sqlRepository.GetCategoryBykey(key);
            return category;
        }
    }
}
