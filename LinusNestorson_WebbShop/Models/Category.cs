﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LinusNestorson_WebbShop.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Category> Categories { get; set; }
        public List<Book> Books { get; set; }
    }
}
