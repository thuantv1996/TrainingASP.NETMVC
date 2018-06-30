using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebsiteBanDongHo.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Bạn cần nhập username")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Bạn cần nhập password")]
        [MinLength(6,ErrorMessage ="Password cần ít nhất 6 kí tự")]
        public string Password { get; set; }
    }
}