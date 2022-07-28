using Technia.Business.Interfaces;
using Technia.Business.Models;
using Technia.Business.Repositories;

namespace Technia.Business
{
    public class TeacherBusiness : ITeacherBusiness

    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherBusiness(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public List<Teacher> GetTeachers() => _teacherRepository.GetTeachers();

        public Teacher SearchTeacherByFullName(string firstName, string lastName)
        {
            return _teacherRepository.SearchTeacherByFullName(firstName, lastName);
        }

        public void UpdateTeacher(Teacher model, string firstName, string lastName)
        {
            _teacherRepository.UpdateTeacher(model, firstName, lastName);
        }

        public void SaveTeacher(Teacher teacher)
        {
            _teacherRepository.SaveTeacher(teacher);
        }
    }
}