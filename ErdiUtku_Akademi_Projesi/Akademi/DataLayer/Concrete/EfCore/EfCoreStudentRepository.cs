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
    public class EfCoreStudentRepository : EfCoreGenericRepository<Student>, IStudentRepository
    {
        public EfCoreStudentRepository(AkademiContext _appContext) : base(_appContext)
        {
        }
        AkademiContext AppContext
        {
            get { return _dbContext as AkademiContext; }
        }

        public async Task CreateStudent(Student student)
        {
            await AppContext.Students.AddAsync(student);
            await AppContext.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllStudentsWithTeachersAsync(bool ApprovedStatus)
        {
            List<Student> students = await AppContext
                .Students
                .Where(s => s.IsApproved == ApprovedStatus)
                .Include(u => u.User)
                .ThenInclude(i => i.Image)
                .Include(s => s.TeacherStudents)
                .ThenInclude(s => s.Teacher)
                .ThenInclude(s => s.User)
                .ToListAsync();
            return students;
        }

        public Task<Student> GetStudentFullDataAsync(int id)
        {
            var stundent = AppContext
                    .Students
                    .Where(s => s.Id == id)
                    .Include(u => u.User)
                    .ThenInclude(i => i.Image)
                    .Include(t => t.TeacherStudents)
                    .ThenInclude(ts => ts.Teacher)
                    .FirstOrDefaultAsync();
            return stundent;
        }

        public async Task<List<Student>> GetStudentsByTeacher(int id)
        {
            List<Student> students = await AppContext
                .Students
                .Where(t => t.IsApproved == true)
                .Include(tu => tu.User)
                .ThenInclude(t => t.Image)
               .Include(t => t.TeacherStudents)
                .ThenInclude(ts => ts.Teacher)
                .ThenInclude(tu => tu.User)
                .ThenInclude(t => t.Image)
                .Where(t => t.TeacherStudents.Any(x => x.StudentId == id))
               .ToListAsync();
            return students;
        }
    }
}
