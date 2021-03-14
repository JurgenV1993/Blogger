﻿using Blogger.BusinessServices.Interface;
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
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);

                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    model.ImageFile.CopyToAsync(fileStream);
                }
                var  category=categoryManager.GetCategoryBykey(model.SelectedCategory);
                lcategory.Add(category);


                Post post = new Post()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Categories = lcategory
                };
                postManager.AddNewPost(post);
            }
            return View();
        }

        private string UploadedFile(PostViewModel model)
        {
            string uniqueFileName = null;

            //if (model.ProfileImage != null)
            //{
            //    string uploadsFolder = Path.Combine(IWebHostEnvironment.WebRootPath, "images");
            //    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
            //    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            //    using (var fileStream = new FileStream(filePath, FileMode.Create))
            //    {
            //        model.ProfileImage.CopyTo(fileStream);
            //    }
            //}
            return uniqueFileName;
        }
    }
}