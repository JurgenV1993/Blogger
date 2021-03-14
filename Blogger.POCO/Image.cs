using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.POCO
{
    public class Image
    {
        public string Title { get; set; }
        public string ImageName { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
