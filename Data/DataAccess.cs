using Microsoft.EntityFrameworkCore;
using Projektuppgift_Databas_Emil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektuppgift_Databas_Emil.Data
{
    internal class DataAccess
    {
        public void Seed()
        {
            using (Context context = new Context())
            {
                var rnd = new Random();

                Author author1 = new Author();
                author1.Name = "Emil Dressel";

                Author author2 = new Author();
                author2.Name = "Nils Axling";

                Author author3 = new Author();
                author3.Name = "Robin Rachoo";

                Customer customer1 = new Customer
                {
                    FirstName = "Filip",
                    LastName = "Sundvall",
                    CardID = 643964789,
                    CardPIN = 9535

                };
                Customer customer2 = new Customer
                {
                    FirstName = "Jonathan",
                    LastName = "Bäckström",
                    CardID = 523544221,
                    CardPIN = 3889
                };
                Customer customer3 = new Customer
                {
                    FirstName = "Michael",
                    LastName = "Puentez",
                    CardID = 943112673,
                    CardPIN = 5449
                };

                Book book1 = new Book();
                book1.title = "C# for Dummies";
                book1.ISBN = rnd.Next(100000000, 999999999);
                book1.Rating = 7;
                book1.ReleaseDate = new DateTime(2019);
                book1.IsRented = false;

                Book book2 = new Book();
                book2.title = "Pingpong";
                book2.ISBN = rnd.Next(100000000, 999999999);
                book2.Rating = 9;
                book2.ReleaseDate = new DateTime(2021);
                book2.IsRented = false;

                Book book3 = new Book();
                book3.title = "Securitas";
                book3.ISBN = rnd.Next(100000000, 999999999); ;
                book3.Rating = 3;
                book3.ReleaseDate = new DateTime(2016);
                book3.IsRented = false;

                context.Authors.AddRange(author1, author2, author3);
                context.Books.AddRange(book1, book2, book3);
                context.Customers.AddRange(customer1, customer2, customer3);

                context.SaveChanges();
            }
        }


        public void AddCustomer(string firstName, string lastName)
        {
            using (var context = new Context())
            {
                var newCustomer = new Customer
                {
                    FirstName = firstName,
                    LastName = lastName,
                };
                context.Customers.Add(newCustomer);
                context.SaveChanges();
            }

        }
        public void AddBook(string bookTitle, DateTime? releaseDate, int rating, List<string> authorNames)
        {
            using (var context = new Context())
            {
                var authors = authorNames.Select(authorName =>
                {
                    var existingAuthor = context.Authors.FirstOrDefault(a => a.Name == authorName);
                    return existingAuthor ?? new Author { Name = authorName };
                }).ToList();

                var newBook = new Book
                {
                    title = bookTitle,
                    ReleaseDate = releaseDate,
                    Rating = rating,
                    Author = authors
                };
                foreach (var author in authors)
                {
                    author.Books.Add(newBook);
                }

                context.Books.Add(newBook);
                context.SaveChanges();
            }
        }
        public void AddAuthor(string name)
        {
            using (var context = new Context())
            {
                var newAuthor = new Author
                {
                    Name = name,

                };
                context.Authors.Add(newAuthor);
                context.SaveChanges();
            }
        }

        public void BorrowBook(int bookId, int customerId)
        {
            using (var context = new Context())
            {              
                Book book = context.Books.Find(bookId);
                Customer customer = context.Customers.Find(customerId);

                if (book != null && customer != null)
                {
                    if (book.LoanDetail == null || book.LoanDetail.ReturnDate != null)
                    {
                        var loanDetails = new LoanDetail
                        {
                            BookID = book.BookID,
                            CustomerID = customer.CustomerID,
                            LoanDate = DateTime.Now,
                            ReturnDate = null
                        };
                        book.LoanDetail = loanDetails;
                        book.IsRented = true;
                        context.LoanDetails.Add(loanDetails);
                        customer.LoanDetails.Add(loanDetails);

                        context.SaveChanges();

                        Console.WriteLine($"'{book.title}' has been rented to {customer.FirstName} {customer.LastName}.");
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, {book.title} has already been rented, please choose another book.");
                    }
                }
                else
                {
                    Console.WriteLine("Error, Please Try Again");
                }
            }
        }




        public void ReturnBook(int bookId)
        {
            using (Context context = new Context())
            {
                Book book = context.Books
                    .Include(b => b.LoanDetail)
                    .FirstOrDefault(b => b.BookID == bookId);

                if (book != null && book.IsRented)
                {
                    book.IsRented = false;
                    book.LoanDetail.ReturnDate = DateTime.Now;

                    context.SaveChanges();
                    Console.WriteLine($"Book '{book.title}' has been returned.");
                }
                else
                {
                    Console.WriteLine("Invalid book or book is not currently rented.");
                }
            }
        }
        public void DeleteCustomer(int customerId)
        {
            Context context = new Context();
            var customerDelete = context.Customers.Find(customerId);
            if (customerDelete != null)
            {
                context.Customers.Remove(customerDelete);
                context.SaveChanges();
                Console.WriteLine($"'{customerDelete.FirstName} {customerDelete.LastName}' Has been removed.");
            }
            else
            {

                Console.WriteLine("Error. Cannot find customer");
            }
        }
        public void DeleteAuthor(int authorID)
        {
            using (Context context = new Context())
            {
                Author author = context.Authors.Find(authorID);
                if (author != null)
                {
                    context.Authors.Remove(author);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Invalid author.");
                }
            }
        }

        public void DeleteBook(int bookID)
        {
            using (Context context = new Context())
            {
                Book book = context.Books.Find(bookID);
                if (book != null)
                {
                    context.Books.Remove(book);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Invalid book.");
                }
            }
        }
    }
}
