using Blogger.BusinessServices.Interface;
using Blogger.POCO;
using Blogger.Web1.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Blogger.Web1.Controllers
{
    public class PostController : Controller
    {
        public ICategoryManager categoryManager;
        public IPostManager postManager;
        private readonly IWebHostEnvironment _hostEnvironment;
        public PostController(ICategoryManager manager, IWebHostEnvironment hostEnvironment, IPostManager postManager)
        {
            this.categoryManager = manager;
            this._hostEnvironment = hostEnvironment;
            this.postManager = postManager;
        }
        [HttpGet]
        public ActionResult Index()
        {
            PostViewModel viewModel = new PostViewModel();
            var categories = categoryManager.DropDownCategories();
            viewModel.Categories = categories;
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Index(PostViewModel model)
        {
            List<Category> lcategory = new List<Category>();
            if (ModelState.IsValid)
            {
                if (model.SelectedCategory != "0") 
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName) + DateTime.Now.ToString("yymmssfff");
                    string extension = Path.GetExtension(model.ImageFile.FileName);
                    fileName = fileName + extension;
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        model.ImageFile.CopyToAsync(fileStream);
                    }

                    Image image = new Image()
                    {
                        Title = "BloggImg",
                        ImageFile = model.ImageFile,
                        ImageName = fileName
                    };
                    postManager.AddNewPostPhoto(image);


                    var category = categoryManager.GetCategoryBykey(model.SelectedCategory);
                    lcategory.Add(category);
                    Post post = new Post()
                    {
                        Title = model.Title,
                        Description = model.Description,
                        CategoryId = Int16.Parse(model.SelectedCategory),
                        Categories = lcategory,
                        PhotoId = fileName
                    };
                    postManager.AddNewPost(post);
                }
            }
            return RedirectToAction("GetAllPost");
        }
        public ActionResult GetAllPost()
        {
            var posts= postManager.GetAllPost();
            
            List<Category> categories = new List<Category>();
            List<PostViewModel> postViewModel = new List<PostViewModel>();


            foreach (var p in posts) 
            {
                var category = categoryManager.GetCategoryBykey(p.CategoryId.ToString());
                categories.Add(category);
                postViewModel.Add(new PostViewModel()
                {
                    Title = p.Title,
                    Description = p.Description,
                    SelectedCategory = p.CategoryId.ToString(),
                    categories = categories,
                    PhotoId =p.PhotoId 
                });
            }
            return View(postViewModel);
        }
    }
}