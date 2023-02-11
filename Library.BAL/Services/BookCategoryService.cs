using Library.BAL.IServices;
using Library.DAL.IRepositories;
using Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BAL.Services
{
    public class BookCategoryService : IBookCategoryService
    {
        readonly IBookCategoryRepository _bookCategoryRepository;
        public BookCategoryService(IBookCategoryRepository bookCategoryRepository)
        {
            _bookCategoryRepository = bookCategoryRepository;
        }
        public async Task<bool> AddBookCategory(string categoryName, int? perantId)
        {
                return await _bookCategoryRepository.AddBookCategory(categoryName, perantId); 

        } 
        public async Task<List<BookCategory>> GetBookCategorires(bool onlyParent)
        {
                return await _bookCategoryRepository.GetBookCategorires(onlyParent); 

        }
        public async Task<List<BookCategory>> GetBookCategoriresByParentId(int perantId)
        {
                return await _bookCategoryRepository.GetBookCategoriresByParentId(perantId); 

        }
    }
}
