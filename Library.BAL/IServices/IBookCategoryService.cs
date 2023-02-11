using Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BAL.IServices
{
    public interface IBookCategoryService
    {
        Task<bool> AddBookCategory(string categoryName, int? perantId);
        Task<List<BookCategory>> GetBookCategorires(bool onlyParent);
        Task<List<BookCategory>> GetBookCategoriresByParentId(int perantId);
    }
}
