﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContentService.Models
{
    public class ContentItemUpdateRequest
    {
       [Key]
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
