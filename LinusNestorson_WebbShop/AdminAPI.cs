﻿using LinusNestorson_WebbShop.Database;
using LinusNestorson_WebbShop.Helpers;
using LinusNestorson_WebbShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinusNestorson_WebbShop
{
    public class AdminAPI
    {
        private ShopContext context = new ShopContext();
        private AdminHelper adminHelp = new AdminHelper();
        private BookHelper bookHelp = new BookHelper();
        private UserHelper userHelp = new UserHelper();

        public bool AddBook(int adminId, int bookId, string title, string author, int price, int amount)
        {
            if (adminHelp.ifAdmin(adminId))
            {
                if (bookHelp.doesBookExist(bookId))
                {
                    var book = context.Books.FirstOrDefault(b => b.Id == bookId);
                    book.Amount = book.Amount + amount;
                    context.Books.Update(book);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    var newBook = new Book() { Title = title, Author = author, Price = price, Amount = amount };
                    context.Books.Add(newBook);
                    context.SaveChanges();
                    return false;
                }
            }
            else return false;
        }
        public void SetAmount(int adminId, int bookId, int amount)
        {
            if (adminHelp.ifAdmin(adminId))
            {
                var book = context.Books.FirstOrDefault(b => b.Id == bookId);
                book.Amount = amount;
                context.Books.Update(book);
                context.SaveChanges();
            }
            else Console.WriteLine("You are not authorized to perform this action");
        }
        public List<User> ListUsers(int adminId)
        {
            if (adminHelp.ifAdmin(adminId))
            {
                return context.Users.OrderBy(u => u.Name).ToList();
            }
            return null;
        }
        public List<User> FindUser(int adminId, string keyword)
        {
            if (adminHelp.ifAdmin(adminId))
            {
                return context.Users.Where(u => u.Name.Contains(keyword)).OrderBy(u => u.Name).ToList();
            }
            return null;
        }
        public bool UpdateBook(int adminId, int bookId, string title, string author, int price)
        {
            if (adminHelp.ifAdmin(adminId))
            {
                if (bookHelp.doesBookExist(bookId))
                {
                    var book = context.Books.FirstOrDefault(b => b.Id == bookId);
                    book.Title = title; book.Author = author; book.Price = price;
                    context.Books.Update(book);
                    context.SaveChanges();
                    return true;
                }
                else return false;
            }
            else return false;
        }
        public bool DeleteBook(int adminId, int bookId)
        {
            if (adminHelp.ifAdmin(adminId))
            {
                var book = context.Books.FirstOrDefault(b => b.Id == bookId);
                book.Amount = book.Amount - 1;
                if (book.Amount <= 0)
                {
                    context.Books.Remove(book);
                    context.SaveChanges();
                    Console.WriteLine("Book is no longer in store. Removed from database");
                }
                context.Books.Update(book);
                context.SaveChanges();
                return true;
            }
            else return false;
        }
        public bool AddCategory(int adminId, string name)
        {
            if (adminHelp.ifAdmin(adminId))
            {
                var newCategory = new Category() { Name = name };
                context.Categories.Add(newCategory);
                context.SaveChanges();
                Console.WriteLine($"{name} was added as a new category");
                return true;
            }
            else return false;
        }
        public bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {
            if (adminHelp.ifAdmin(adminId))
            {
                var book = context.Books.FirstOrDefault(b => b.Id == bookId);
                book.Category = context.Categories.FirstOrDefault(c => c.Id == categoryId);
                context.Books.Update(book);
                context.SaveChanges();
                Console.WriteLine($"The book was given the category {book.Category.Name}");
                return true;
            }
            else return false;
        }
        public bool UpdateCategory(int adminId, int categoryId, string catName)
        {
            if (adminHelp.ifAdmin(adminId))
            {
                var category = context.Categories.FirstOrDefault(b => b.Id == categoryId);
                category.Name = catName;
                context.Categories.Update(category);
                context.SaveChanges();
                Console.WriteLine($"The catagory was changed to {category.Name}");
                return true;
            }
            else return false;
        }
        public bool DeleteCatagory(int adminId, int categoryId) // Skall enbart raderas om det inte finns några bäcker kopplade till kategorin
        {
            if (adminHelp.ifAdmin(adminId))
            {
                var category = context.Categories.FirstOrDefault(c => c.Id == categoryId);
                var book = context.Books.FirstOrDefault(b => b.Category.Id == categoryId);
                if (category != null && book == null)
                {
                    context.Categories.Remove(category);
                    Console.WriteLine($"{category.Name} was removed from categories");
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    Console.WriteLine("There is still books in this category. Remove them first.");
                    return false;
                }
            }
            else return false;
        }

        //GÖR KLART DENNA METOD! (ADDUSER())
        //public bool AddUser(int adminId, string name, string Password)
        //{
        //    if (adminHelp.ifAdmin(adminId))
        //    {
        //        if (userHelp.doesUserExist(name))
        //        {
        //            var user = context.Users.FirstOrDefault(u => u.Name == name);
        //            book.Amount = book.Amount + amount;
        //            context.Books.Update(book);
        //            context.SaveChanges();
        //            return true;
        //        }
        //        else
        //        {
        //            var newBook = new Book() { Title = title, Author = author, Price = price, Amount = amount };
        //            context.Books.Add(newBook);
        //            context.SaveChanges();
        //            return false;
        //        }
        //    }
        //    else return false;
        //}
    }
}
