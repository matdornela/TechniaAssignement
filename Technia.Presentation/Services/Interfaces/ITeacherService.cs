using Technia.Presentation.DTOs;

namespace Technia.Presentation.Services.Interfaces
{
    public interface ITeacherService
    {
        List<TeacherDto> GetTeachers();

        TeacherDto SearchTeacherByFullName(string firstName, string lastName);

        void UpdateTeacher(TeacherDto teacher, string firstName, string lastName);

        void SaveTeacher(TeacherDto teacher);
    }
}