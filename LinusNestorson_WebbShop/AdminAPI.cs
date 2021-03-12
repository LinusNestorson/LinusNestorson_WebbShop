using LinusNestorson_WebbShop.Database;
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

        }
    }
}

