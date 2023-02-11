using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Models
{
    public class SpBook
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public DateTime BookPublishDate { get; set; }
        public string AuthorName { get; set; }
        public string BookCategoryName { get; set; }
    }
}
