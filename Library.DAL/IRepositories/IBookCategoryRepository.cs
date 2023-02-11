using Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.IRepositories
{
    public interface IBookCategoryRepository
    {
        Task<bool> AddBookCategory(string categoryName, int? parentId);
        Task<List<BookCategory>> GetBookCategorires(bool onlyParent);
        Task<List<BookCategory>> GetBookCategoriresByParentId(int id);
    }
}
