using Blogger.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.Web1.Models.ViewModels
{
    public class PostViewModel
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public List<Category> Categories { get; set; }
    }
}
