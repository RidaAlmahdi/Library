using Library.BAL.Helper;
using Library.BAL.IServices;
using Library.BAL.Services;
using Library.DAL.Models;
using Llibrary.DTOs.Author;
using Llibrary.DTOs.Book;
using Llibrary.DTOs.BookCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Llibrary.Controllers
{
    public class BookController : Controller
    {
        private IBookService _bookService;
        private IBookCategoryService _bookCategoryService;
        private IAuthorService _authorService;
        public IConfiguration _configuration { get; }

        public BookController(IBookService bookService, IBookCategoryService bookCategoryService, IAuthorService authorService, IConfiguration configuration)
        {
            _bookService = bookService;
            _bookCategoryService = bookCategoryService;
            _authorService = authorService;
            _configuration = configuration;

        }
        public async Task<IActionResult> Index()
        {
            var bookCategorires = await _bookCategoryService.GetBookCategorires(false);
            ViewBag.bookCategorires = bookCategorires;
            var authors = await _authorService.GetAuthors();
            ViewBag.authors = authors;

            return View();
        }
        public async Task<IActionResult> GetBooksByEF()
        {
            var books = await _bookService.GetBooksByEF();
        
            ViewBag.books = books;

            return View();
        }
       
        public async Task<IActionResult> GetBooksByStoredProcedure()
        {
            var books = await _bookService.GetBooksByStoredProcedure(_configuration.GetConnectionString("DefaultConnection"));
        
            ViewBag.books = books;

            return View();
        }

        [HttpGet("api/[controller]/GetBooksByStoredProcedure")]
        [Produces(typeof(List<SpBook>))]

        public async Task<IActionResult> GetBooksByStoredProcedureApi()
        {
            var books = await _bookService.GetBooksByStoredProcedure(_configuration.GetConnectionString("DefaultConnection"));

            return Ok(books);
        }
        
        [HttpGet("api/[controller]/GetBooksByEF")]
        [Produces(typeof(List<Book>))]
        public async Task<IActionResult> GetBooksByEFApi()
        {
            var books = await _bookService.GetBooksByEF();

            return Ok(books);
        }

        [HttpPost("api/[controller]/AddBook")]
        [Produces(typeof(bool))]

        public async Task<IActionResult> AddBook([FromBody] AddBookDto model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                var result = await _bookService.AddBook(model.Name, model.PublishDate,model.CategoryId,model.AuthorId);


                return Ok(result);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
