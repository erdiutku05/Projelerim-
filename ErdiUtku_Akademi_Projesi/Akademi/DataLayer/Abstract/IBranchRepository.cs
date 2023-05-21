using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Abstract
{
    public interface IBranchRepository : IGenericRepository<Branch>
    {
        Task<string> GetBranchNameByUrlAsync(string url);

        Task<List<Branch>> GetBranchesAsync(bool ApprovedStatus);

        Task<List<Branch>> GetAllBranchesFullDataAsync(bool ApprovedStatus);

        Task<List<Branch>> GetBranchesByTeacherAsync(int id);

        Task<Branch> GetBranchFullDataAsync(int id);
    }
}
