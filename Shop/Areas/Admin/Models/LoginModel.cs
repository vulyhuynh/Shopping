﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Chưa nhập username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Chưa nhập passwork")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}