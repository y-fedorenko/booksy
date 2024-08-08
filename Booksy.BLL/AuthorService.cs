using Booksy.Models;
using Booksy.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booksy.BLL
{
    public class AuthorService
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
