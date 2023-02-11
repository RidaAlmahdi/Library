using System;
using System.ComponentModel.DataAnnotations;

namespace Llibrary.DTOs.Book
{
    public class AddBookDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int AuthorId { get; set; }
    }
}
