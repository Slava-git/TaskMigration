using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithMigrations.Entities
{
    public class BookReview
    {
        public int Id { get; set; }
        public string ReviewerName { get; set; }
        public int Rating { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
