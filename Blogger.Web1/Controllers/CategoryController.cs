using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogger.BusinessServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.Web1.Controllers
{
    public class CategoryController : Controller
    {
        BL_CategoryManager bL_CategoryManager;
        public ActionResult Index()
        {
         var categories= bL_CategoryManager.GetAllCategories();
            return View();
        }
    }
}