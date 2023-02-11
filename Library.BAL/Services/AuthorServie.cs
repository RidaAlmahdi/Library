using Library.BAL.IServices;
using Library.DAL.IRepositories;
using Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library.BAL.Services
{
    public class AuthorService : IAuthorService
    {
        readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<bool> AddAuthor(string name, string phoneNumber)
        {
                return await _authorRepository.AddAuthor(name, phoneNumber); 

        }

        public async Task<List<Author>> GetAuthors()
        {
            return await _authorRepository.GetAuthors();

        }
    }
}
