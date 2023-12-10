using Projektuppgift_Databas_Emil.Data;

namespace Projektuppgift_Databas_Emil
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.Seed();

            /*
            dataAccess.AddAuthor("Stefan Kureljusic");
            Console.WriteLine("Author has been added.");
           */

            //3.Create a new book
            //List<string> authorNames = new List<string> { "Manu St.Hill" };
            //dataAccess.AddBook("Martial Arts for Dummies", new DateTime(2020), 8, authorNames);
            //Console.WriteLine("Book has been added.");



            //4.Create a new customer
            //dataAccess.AddCustomer("Nils", "Axling");
            //Console.WriteLine("Customer has been added.");

            //5.Borrow a book
            //dataAccess.BorrowBook(1, 1);

            //6.Return a book
            //int bookIdToReturn = 1;
            //int customerIdReturning = 1;
            //dataAccess.ReturnBook(bookIdToReturn);

            //7. Delete customer
            //int borrowerIdToDelete = 3;
            //dataAccess.DeleteBorrower(borrowerIdToDelete);

            //Delete Book
            //int authorIdToDelete = 1;
            //dataAccess.DeleteAuthor(authorIdToDelete);
            //Console.WriteLine("Author has been deleted");

            //Delete Author
            //int bookIdToDelete = 3;
            //dataAccess.DeleteBook(bookIdToDelete);
            //Console.WriteLine("Book has been deleted.");
        }
    }
}