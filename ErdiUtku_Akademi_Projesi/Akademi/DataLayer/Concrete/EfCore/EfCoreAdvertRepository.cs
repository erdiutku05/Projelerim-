using DataLayer.Abstract;
using DataLayer.Concrete.EfCore.Context;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Concrete.EfCore
{
    public class EfCoreAdvertRepository : EfCoreGenericRepository<Advert>, IAdvertRepository
    {
        public EfCoreAdvertRepository(AkademiContext _appContext) : base(_appContext)
        {
        }

        AkademiContext AppContext
        {
            get { return _dbContext as AkademiContext; }
        }

        public async Task<Advert> GetAdvertFullDataAsync(int id)
        {
            var adverts = await AppContext
                .Adverts
                .Where(t => t.Id == id)
                .Include(t => t.Teacher)
                .ThenInclude(t => t.TeacherBranches)
                .ThenInclude(tb => tb.Branch)
                .Include(t => t.Teacher)
                .ThenInclude(u => u.User)
                .ThenInclude(t => t.Image)
                .FirstOrDefaultAsync();
            return adverts;
        }

        public Task<List<Advert>> GetAdvertsFullDataAsync(string id, bool approvedStatus)
        {
            var adverts = AppContext
                .Adverts
                .Include(a => a.Teacher)
                .ThenInclude(u => u.User)
                .ThenInclude(i => i.Image)
                .Include(a => a.Teacher)
                .ThenInclude(t => t.TeacherBranches)
                .ThenInclude(tb => tb.Branch)
                .AsQueryable();
            if (id != null)
            {
                adverts = adverts.Where(a => a.Teacher.User.Id == id);
            }
            return adverts.ToListAsync();
        }

        public Task<List<Advert>> GetAllAdvertsAsync(bool approvedStatus)
        {
            var adverts = AppContext
                        .Adverts
                         .Include(a => a.Teacher)
                        .ThenInclude(u => u.User)
                        .ThenInclude(i => i.Image)
                        .Include(a => a.Teacher)
                        .ThenInclude(t => t.TeacherBranches)
                        .ThenInclude(tb => tb.Branch)
                        .Where(a => a.IsApproved == approvedStatus)
                        .ToListAsync();
            return adverts;
        }

        public Task<int> GetByUrlAsync(string url)
        {
            var result = AppContext.Adverts.Where(t => t.Url == url).Select(t => t.Id).FirstOrDefaultAsync();
            return result;
        }
    }
}
