using Booksy.DAL;
using Booksy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booksy.BLL
{
    public class SerieService
    {
        private readonly SerieDAL _dal;

        public SerieService(SerieDAL dal)
        {
            _dal = dal;
        }

        public async Task<List<Serie>> GetSeriesAsync()
        {
            return await _dal.GetSeriesAsync();
        }

        public async Task<Serie> GetSerieAsync(int id)
        {
            return await _dal.GetSerieAsync(id);
        }

        public async Task AddSerieAsync(Serie serie)
        {
            await _dal.AddSerieAsync(serie);
        }

        public async Task UpdateSerieAsync(Serie serie)
        {
            await _dal.UpdateSerieAsync(serie);
        }

        public async Task DeleteSerieAsync(int id)
        {
            await _dal.DeleteSerieAsync(id);
        }
    }
}
