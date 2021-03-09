﻿using LinusNestorson_WebbShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinusNestorson_WebbShop.Database
{
    public class ShopContext : DbContext
    {
        private const string DatabaseName = "WebbShopLinusNestorson";

        public DbSet<User> Users { get; set;}
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<SoldBook> SoldBooks { get; set; }

        // TODO: Skapa DbSet för users
        // TODO: Skapar DbSet för Category
        // TODO: Skapa DbSet för Books
        // TODO: Skapa DbSet för Sold Books

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Server = .\SQLExpress;Database={DatabaseName};trusted_connection=true");
        }
    }
}
