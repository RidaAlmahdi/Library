using Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BAL.IServices
{
    public interface IAuthorService
    {
        Task<bool> AddAuthor(string name, string phoneNumber);
        Task<List<Author>> GetAuthors();
    }
}
