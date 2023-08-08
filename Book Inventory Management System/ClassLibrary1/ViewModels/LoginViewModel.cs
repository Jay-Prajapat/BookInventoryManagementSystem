﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibrary1.ViewModels
{
    public  class LoginViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        [RegularExpression("^[a-zA-Z0-9_-]{4,20}$", ErrorMessage = "User Name must be between 4 and 20 characters and contain only latters, numbers, underscores or hyphens.")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*])[a-zA-Z\\d!@#$%^&*]{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public string Password { get; set; }
    }
}
