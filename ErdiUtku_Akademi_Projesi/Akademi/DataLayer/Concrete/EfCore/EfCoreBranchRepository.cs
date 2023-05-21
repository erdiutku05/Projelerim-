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
    public class EfCoreBranchRepository : EfCoreGenericRepository<Branch>, IBranchRepository
    {
        public EfCoreBranchRepository(AkademiContext _appContext) : base(_appContext)
        {
        }

        AkademiContext AppContext
        {
            get { return _dbContext as AkademiContext; }
        }

        public async Task<string> GetBranchNameByUrlAsync(string url)
        {
            Branch branch = await AppContext
                        .Branches
                        .Where(b => b.Url == url)
                        .FirstOrDefaultAsync();
            return branch.BranchName;
        }

        public async Task<List<Branch>> GetBranchesAsync(bool ApprovedStatus)
        {
            return await AppContext
                 .Branches
                 .Where(c => c.IsApproved == ApprovedStatus)
                 .ToListAsync();
        }

        public async Task<List<Branch>> GetAllBranchesFullDataAsync(bool ApprovedStatus)
        {
            return await AppContext
                .Branches
                .Where(x => x.IsApproved == ApprovedStatus)
                .Include(x => x.TeacherBranches)
                .ThenInclude(s => s.Teacher)
                .ThenInclude(s => s.User)
                .ToListAsync();
        }

        public async Task<Branch> GetBranchFullDataAsync(int id)
        {
            return await AppContext
                .Branches
                .Where(c => c.Id == id)
                .Include(s => s.TeacherBranches)
                .ThenInclude(s => s.Teacher)
                .ThenInclude(u => u.User)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Branch>> GetBranchesByTeacherAsync(int id)
        {
            List<Branch> branches = await AppContext
               .Branches
               .Where(b => b.IsApproved == true)
               .Include(t => t.TeacherBranches)
               .ThenInclude(tb => tb.Teacher)
               .Where(tb => tb.TeacherBranches.Any(x => x.TeacherId == id))
               .ToListAsync();
            return branches;
        }
    }
}
