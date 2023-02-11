using Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.IRepositories
{
    public interface IBookRepository
    {
        Task<bool> AddBook(string name, DateTime publishDate, int categoryId, int authorId);
        Task<List<Book>> GetBooksByEF();
        Task<List<SpBook>> GetBooksByStoredProcedure(string connectionString);
    }
}
