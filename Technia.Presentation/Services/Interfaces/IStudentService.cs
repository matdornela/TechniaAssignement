using Technia.Presentation.DTOs;

namespace Technia.Presentation.Services.Interfaces
{
    public interface IStudentService
    {
        List<StudentDto> GetStudents();

        StudentDto SearchStudentByFullName(string firstName, string lastName);

        void UpdateStudent(StudentDto model, string firstName, string lastName);

        void SaveStudent(StudentDto student);
    }
}