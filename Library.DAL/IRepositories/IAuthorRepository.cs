using Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.IRepositories
{
    public interface IAuthorRepository
    {
        Task<bool> AddAuthor(string name, string phoneNumber);
        Task<List<Author>> GetAuthors();
    }
}
