using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Security.Principal;

namespace Llibrary.DTOs.Author
{
    public class AddAuthorDto
    {
     
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
