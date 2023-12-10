using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektuppgift_Databas_Emil.Models
{
    internal class LoanDetail
    {
        public int LoanDetailID { get; set; }
        public int BookID { get; set; }
        public int CustomerID { get; set; }
        public DateTime? LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
        public Customer? customer { get; set; }


    }
}
