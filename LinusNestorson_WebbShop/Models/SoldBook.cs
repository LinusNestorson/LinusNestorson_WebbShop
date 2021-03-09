﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LinusNestorson_WebbShop.Models
{
    public class SoldBook
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public DateTime PurchasedDate { get; set;}
        public int UserId { get; set; }
    }
}
