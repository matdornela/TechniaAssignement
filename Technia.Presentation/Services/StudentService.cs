using AutoMapper;
using Technia.Business.Interfaces;
using Technia.Business.Models;
using Technia.Presentation.DTOs;
using Technia.Presentation.Services.Interfaces;

namespace Technia.Presentation.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentBusiness _studentBusiness;
        private readonly IMapper _mapper;

        public StudentService(IStudentBusiness studentBusiness, IMapper mapper)
        {
            _studentBusiness = studentBusiness;
            _mapper = mapper;
        }

        public List<StudentDto> GetStudents()
        {
            var data = _studentBusiness.GetStudents();

            var dataMapped = _mapper.Map<List<StudentDto>>(data);
            return dataMapped;
        }

        public StudentDto SearchStudentByFullName(string firstName, string lastName)
        {
            var data = _studentBusiness.SearchStudentByFullName(firstName, lastName);

            var dataMapped = _mapper.Map<StudentDto>(data);

            return dataMapped;
        }

        public void UpdateStudent(StudentDto student, string firstName, string lastName)
        {
            var model = _mapper.Map<Student>(student);
            _studentBusiness.UpdateStudent(model, firstName, lastName);
        }

        public void SaveStudent(StudentDto student)
        {
            var model = _mapper.Map<Student>(student);
            _studentBusiness.SaveStudent(model);
        }
    }
}