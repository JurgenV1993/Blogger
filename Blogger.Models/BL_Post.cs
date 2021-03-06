using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.Models
{
    public class BL_Post
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public List<BL_Category> Categories { get; set; }
    }
}
