using System.ComponentModel.DataAnnotations;

namespace Llibrary.DTOs.BookCategory
{
    public class AddBookCategoryDto
    {
        [Required]
        public string CategoryName { get; set; }
        public int? PerantId { get; set; }
    }
}
