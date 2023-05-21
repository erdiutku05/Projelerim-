using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Abstract
{
    public interface IAdvertRepository : IGenericRepository<Advert>
    {
        Task<List<Advert>> GetAdvertsFullDataAsync(string id, bool approvedStatus);
        Task<List<Advert>> GetAllAdvertsAsync(bool approvedStatus);
        Task<int> GetByUrlAsync(string url);
        Task<Advert> GetAdvertFullDataAsync(int id);
    }
}
