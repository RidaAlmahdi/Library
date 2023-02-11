using Library.DAL.Data;
using Library.DAL.IRepositories;
using Library.DAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        protected readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> AddBook(string name, DateTime publishDate,int categoryId, int authorId)
        {
            bool result = false;

            try
            {
                Book newBook = new Book
                {
                    Name = name,
                    PublishDate = publishDate,
                    BookCategoryId = categoryId,
                    AuthorId = authorId,
                };
                _context.Books.Add(newBook);
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
        public async Task<List<Book>> GetBooksByEF()
        {

            var books = await _context.Books.Include(c => c.BookCategory).Include(c => c.Author).ToListAsync();
            return books;
        }

        public async Task<List<SpBook>> GetBooksByStoredProcedure(string connectionString)
        {
            var result = new List<SpBook>();
            try
            {
                using (SqlConnection Coon = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("dbo.spGetBooks", Coon);
                    Coon.Open();
                    using (SqlDataReader oReader = await cmd.ExecuteReaderAsync())
                    {
                        while (await oReader.ReadAsync())
                        {
                            result.Add(new SpBook
                            {
                                BookId = (int)oReader["bookId"],
                                BookName = oReader["bookName"].ToString(),
                                BookPublishDate = (DateTime)oReader["bookPublishDate"],
                                BookCategoryName = oReader["categoryName"].ToString(),
                                AuthorName = oReader["authorName"].ToString(),
                                
                            });
                        }
                    }

                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
