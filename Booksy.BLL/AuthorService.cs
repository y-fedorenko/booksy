using Booksy.Models;
using Booksy.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booksy.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int id);
        Task AddAuthorAsync(Author author);
        Task UpdateAuthorAsync(Author author);
        Task DeleteAuthorAsync(int id);
    }

    public class AuthorService : IAuthorService
    {
        private readonly AuthorDAL _authorDAL;

        public AuthorService(AuthorDAL authorDAL)
        {
            _authorDAL = authorDAL;
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await _authorDAL.GetAllAuthorsAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await _authorDAL.GetAuthorByIdAsync(id);
        }

        public async Task AddAuthorAsync(Author author)
        {
            await _authorDAL.AddAuthorAsync(author);
        }

        public async Task UpdateAuthorAsync(Author author)
        {
            await _authorDAL.UpdateAuthorAsync(author);
        }

        public async Task DeleteAuthorAsync(int id)
        {
            await _authorDAL.DeleteAuthorAsync(id);
        }
    }
}
