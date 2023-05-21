using EntityLayer.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBranchService
    {
        Task CreateAsync(Branch branch);

        Task<Branch> GetByIdAsync(int id);

        Task<List<Branch>> GetAllAsync();

        void Update(Branch branch);

        void Delete(Branch branch);

        Task<string> GetBranchNameByUrlAsync(string url);

        Task<List<Branch>> GetBranchesAsync(bool ApprovedStatus);

        Task<Branch> GetBranchFullDataAsync(int id);

        Task<List<Branch>> GetAllBranchesFullDataAsync(bool ApprovedStatus);
        Task<List<Branch>> GetBranchesByTeacherAsync(int id);


    }
}
