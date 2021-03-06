using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.POCO
{
    public class Post
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public List<Category> Categories { get; set; }
    }
}
