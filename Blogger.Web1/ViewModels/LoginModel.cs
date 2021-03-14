using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.Web1.Models.ViewModels
{
    public class LoginModel
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [UIHint("password")]
        public string Password { get; set; }
    }
}
