using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektuppgift_Databas_Emil.Models
{
    internal class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? CardID { get; set; }
        public int CardPIN { get; set; }
        public ICollection<LoanDetail> LoanDetails { get; set; } = new List<LoanDetail>();

        public Customer()
        {
            
        }
    }
}
