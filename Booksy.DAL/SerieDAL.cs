using Booksy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booksy.DAL
{
    public class SerieDAL
    {
        public readonly BooksyDbContext _context;
        public SerieDAL(BooksyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Serie>> GetSeriesAsync()
        {
            return await _context.Series.ToListAsync();
        }

        public async Task<Serie> GetSerieAsync(int id)
        {
            return await _context.Series.FindAsync(id);
        }

        public async Task AddSerieAsync(Serie serie)
        {
            _context.Series.Add(serie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSerieAsync(Serie serie)
        {
            _context.Series.Update(serie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSerieAsync(int id)
        {
            var serie = await _context.Series.FindAsync(id);
            if (serie != null)
            {
                _context.Series.Remove(serie);
                await _context.SaveChangesAsync();
            }
        }
    }
}
