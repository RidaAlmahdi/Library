using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Models
{
    public class BookCategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int? ParentBookCategoryId { get; set; }

        [ForeignKey("ParentBookCategoryId")]
        public BookCategory ParentBookCategory { get; set; }

        public ICollection<Book> Books { get; set; }



    }
}
