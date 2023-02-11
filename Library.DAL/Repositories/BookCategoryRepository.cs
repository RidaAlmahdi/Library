using Library.DAL.Data;
using Library.DAL.IRepositories;
using Library.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    public class BookCategoryRepository : IBookCategoryRepository
    {
        protected readonly ApplicationDbContext _context;

        public BookCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> AddBookCategory(string categoryName, int? ParentId)
        {
            bool result = false;

            try
            {
                BookCategory newBookCategory = new BookCategory
                {
                    CategoryName = categoryName,
                    ParentBookCategoryId = ParentId == -1 ? null : ParentId

                };
                _context.BookCategories.Add(newBookCategory);
                await _context.SaveChangesAsync();
                result = true;
                return result;
            }
            catch (Exception)
            {
                return result;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<BookCategory>> GetBookCategorires(bool onlyParent)
        {

            IQueryable<BookCategory> parentBookCategories = _context.BookCategories;
            if (onlyParent)
            {
                parentBookCategories = parentBookCategories.Where(c => c.ParentBookCategoryId == null);
            }

            var content = await parentBookCategories.ToListAsync();
            return content;
        }

        public async Task<List<BookCategory>> GetBookCategoriresByParentId(int id)
        {
            var bookCategories = await _context.BookCategories.Where(c => c.ParentBookCategoryId == id).ToListAsync();
            return bookCategories;
        }
    }
}
