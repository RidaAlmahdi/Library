using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int BookCategoryId { get; set; }
        public BookCategory BookCategory { get; set; }

    }
}
