﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShowTime.Models
{
    public class User
    {
        [Key]
        public int user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

    }
}