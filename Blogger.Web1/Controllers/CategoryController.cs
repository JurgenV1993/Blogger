using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogger.BusinessServices;
using Blogger.BusinessServices.Interface;
using Blogger.Web1.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.Web1.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        public ICategoryManager manager;

        public CategoryController(ICategoryManager manager)
        {
            this.manager = manager;
        }
        public ActionResult Index()
        {
         var categories= manager.GetAllCategories();
            List<CategoryModel> cmodel = new List<CategoryModel>();
            foreach (var c in categories ) 
            {
                cmodel.Add(new CategoryModel 
                {
                     CategoryName=c.CategoryName ,
                     CategoryDescription =c.CategoryDescription,
                     Id=c.ID 
                });
            }
            return View(cmodel);
        }
    }
}