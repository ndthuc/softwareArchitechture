﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTfulAPI_Homework09.Models
{
    public class RegisterUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}