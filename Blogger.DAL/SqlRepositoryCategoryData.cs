using Blogger.DAL.Interface;
using Blogger.Models;
using Blogger.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blogger.DAL
{
    public class SqlRepositoryCategoryData : IRepositoryCategory
    {
        public readonly MyCotext conn;
        public SqlRepositoryCategoryData()
        {
            conn = new MyCotext();
        }
        public List<Category> GetAllCategory()
        {
            IQueryable<BL_Category> category = from c in conn.Categories
                                               select c;

            List<Category> list = new List<Category>();
            foreach (var c in category) 
            {
                list.Add(ConvertEntitytoPoco(c));
            }
            return list;
        }
        public Category ConvertEntitytoPoco(BL_Category category) {

            Category c = new Category();
            c.CategoryDescription = category.CategoryDescription;
            c.CategoryName = category.CategoryName;
            c.PostID = category.PostID;
            return c;
        }
    }
}
