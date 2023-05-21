using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Abstract
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
        Task<List<Teacher>> GetAllTeachersFullDataAsync(bool IsApproved, string branchurl);
        Task CreateTeacher(Teacher teacher, int[] SelectedBranches);

        Task<Teacher> GetTeacherFullDataAsync(int id);
        Task<Teacher> GetTeacherFullDataStringAsync(string Name);


        Task UpdateTeacher(Teacher teacher, int[] SelectedBranches);
        Task<List<Teacher>> GetTeachersByBranch(int id);
        Task<List<Teacher>> GetTeachersByStudent(int id);
        Task<int> GetByUrlAsync(string url);
    }
}
