﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Assignment.API.Models
{
    public class LoginModel
    {
        [Required]
        public string EmailId { get; set; }
       
        [Required]
        public string Password { get; set; }
    }
}
