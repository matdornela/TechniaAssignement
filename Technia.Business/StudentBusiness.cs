using Technia.Business.Interfaces;
using Technia.Business.Models;
using Technia.Business.Repositories;

namespace Technia.Business
{
    public class StudentBusiness : IStudentBusiness
    {
        private readonly IStudentRepository _studentRepository;

        public StudentBusiness(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<Student> GetStudents() => _studentRepository.GetStudents();

        public Student SearchStudentByFullName(string firstName, string lastName)
        {
            return _studentRepository.SearchStudentByFullName(firstName, lastName);
        }

        public void UpdateStudent(Student model, string firstName, string lastName)
        {
            _studentRepository.UpdateStudent(model, firstName, lastName);
        }

        public void SaveStudent(Student student)
        {
            _studentRepository.SaveStudent(student);
        }
    }
}