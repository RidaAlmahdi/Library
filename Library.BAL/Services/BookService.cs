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
    public class BookService : IBookService
    {
        readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<bool> AddBook(string name, DateTime publishDate, int categoryId, int authorId)
        {
                return await _bookRepository.AddBook(name, publishDate,categoryId,authorId); 

        } 

        public async Task<List<Book>> GetBooksByEF()
        {

                return await _bookRepository.GetBooksByEF();
        }
        public async Task<List<SpBook>> GetBooksByStoredProcedure(string connectionString)
        {

            return await _bookRepository.GetBooksByStoredProcedure(connectionString);
        }
    }
}
