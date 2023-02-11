using Library.BAL.IServices;
using Library.BAL.Services;
using Library.DAL.Models;
using Llibrary.DTOs.Author;
using Llibrary.DTOs.BookCategory;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Llibrary.Controllers
{
    public class BookCategoryController : Controller
    {
        private IBookCategoryService _bookCategoryService;
        public BookCategoryController(IBookCategoryService bookCategoryService)
        {
            _bookCategoryService = bookCategoryService;

        }
        public async Task<IActionResult> Index()
        {
            var parentBookCategorires = await _bookCategoryService.GetBookCategorires(true);
            ViewBag.parentBookCategorires = parentBookCategorires;

            return View();
        }

        public async Task<IActionResult> FilterBookCategory()
        {
            var parentBookCategorires = await _bookCategoryService.GetBookCategorires(true);
            ViewBag.parentBookCategorires = parentBookCategorires;

            return View();
        }

        [HttpPost("api/[controller]/AddBookCategory")]
        [Produces(typeof(bool))]
        public async Task<IActionResult> AddBookCategory([FromBody] AddBookCategoryDto model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                var result = await _bookCategoryService.AddBookCategory(model.CategoryName, model.PerantId);


                return Ok(result);

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet("[controller]/api/GetBookCategoryByParentId/{id}")]
        [Produces(typeof(List<BookCategory>))]
        public async Task<IActionResult> GetBookCategoryByParentId(int id)
        {
            try
            {
                var result = await _bookCategoryService.GetBookCategoriresByParentId(id);
                    
                return Ok(result);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
        
        [HttpGet("/api/[controller]/GetBookCategories")]
        [Produces(typeof(List<BookCategory>))]
        public async Task<IActionResult> GetBookCategoriesApi(bool parentOnly)
        {
            try
            {
                var parentBookCategorires = await _bookCategoryService.GetBookCategorires(parentOnly);

                return Ok(parentBookCategorires);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
