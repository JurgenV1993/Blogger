using Blogger.BusinessServices.Interface;
using Blogger.DAL;
using Blogger.DAL.Interface;
using Blogger.POCO;
using System;
using System.Collections.Generic;

namespace Blogger.BusinessServices
{
    public class BL_CategoryManager: ICategory_Manager
    {
        public readonly IRepositoryCategoryData sqlRepository;
        public BL_CategoryManager(IRepositoryCategoryData sqlRepository)
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
