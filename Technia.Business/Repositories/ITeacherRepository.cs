using Technia.Business.Models;

namespace Technia.Business.Repositories
{
    public interface ITeacherRepository
    {
        List<Teacher> GetTeachers();

        Teacher SearchTeacherByFullName(string firstName, string lastName);

        void UpdateTeacher(Teacher model, string firstName, string lastName);

        void SaveTeacher(Teacher teacher);
    }
}