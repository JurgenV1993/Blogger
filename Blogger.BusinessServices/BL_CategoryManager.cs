using Blogger.BusinessServices.Interface;
using Blogger.DAL;
using Blogger.POCO;
using System;
using System.Collections.Generic;

namespace Blogger.BusinessServices
{
    public class BL_CategoryManager: ICategoryManager
    {
        public readonly SqlRepositoryCategoryData sqlRepository;
        public BL_CategoryManager(SqlRepositoryCategoryData sqlRepository)
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
    }
}
