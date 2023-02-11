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
    public class AuthorRepository : IAuthorRepository
    {
        protected readonly ApplicationDbContext _context;

        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> AddAuthor(string name, string phoneNumber)
        {
            bool result = false;

            try
            {
                Author newAuthor = new Author
                {
                    Name = name,
                    PhoneNumber = phoneNumber,
                };
                _context.Authors.Add(newAuthor);
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
        public async Task<List<Author>> GetAuthors()
        {

            var events = await _context.Authors.ToListAsync();
            return events;
        }
    }
}
