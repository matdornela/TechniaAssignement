using Technia.Business.Models;

namespace Technia.Business.Interfaces
{
    public interface IStudentBusiness
    {
        List<Student> GetStudents();

        Student SearchStudentByFullName(string firstName, string lastName);

        void UpdateStudent(Student model, string firstName, string lastName);

        void SaveStudent(Student student);
    }
}