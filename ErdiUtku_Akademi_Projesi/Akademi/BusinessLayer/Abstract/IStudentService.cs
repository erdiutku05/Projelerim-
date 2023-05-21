using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IStudentService
    {
        Task CreateAsync(Student student);

        Task<Student> GetByIdAsync(int id);

        Task<List<Student>> GetAllAsync();

        void Update(Student student);

        void Delete(Student student);

        Task CreateStudent(Student student);

        Task<List<Student>> GetAllStudentsWithTeachersAsync(bool ApprovedStatus);

        Task<Student> GetStudentFullDataAsync(int id);

        Task<List<Student>> GetStudentsByTeacher(int id);

    }
}
