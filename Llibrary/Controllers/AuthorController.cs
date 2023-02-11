using Library.BAL.IServices;
using Llibrary.DTOs.Author;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Llibrary.Controllers
{
   
    public class AuthorController : Controller
    {
        private IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("api/[controller]/AddAuthor")]
        public async Task<IActionResult> AddAuthor([FromBody]AddAuthorDto model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                var result = await _authorService.AddAuthor(model.Name, model.PhoneNumber);


                return Ok(result);

            }
            catch (System.Exception)
            {

                throw;
            }
        }

    }
}
