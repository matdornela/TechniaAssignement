using Technia.Business.Models;

namespace Technia.Business.Repositories
{
    public interface IStudentRepository
    {
        List<Student> GetStudents();

        Student SearchStudentByFullName(string firstName, string lastName);

        void UpdateStudent(Student model, string firstName, string lastName);

        void SaveStudent(Student student);
    }
}