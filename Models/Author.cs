using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektuppgift_Databas_Emil.Models
{
    internal class Author
    {
        public int AuthorID { get; set; }
        public string Fullname { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();

        public Author()
        {
            
        }
    }
}
