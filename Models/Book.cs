using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektuppgift_Databas_Emil.Models
{
    internal class Book
    {
        public int BookID { get; set; }
        public string title { get; set; }
        public ICollection<Author> Author { get; set; } = new List<Author>();

        public int ISBN { get; set; }

        public DateTime? ReleaseDate { get; set; }
        public int Rating { get; set; }
        public bool IsRented { get; set; }

        [ForeignKey("LoanDetailID")]
        public LoanDetail? LoanDetail { get; set; }

    }
}
