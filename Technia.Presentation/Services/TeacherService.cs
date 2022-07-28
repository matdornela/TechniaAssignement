using AutoMapper;
using Technia.Business.Interfaces;
using Technia.Business.Models;
using Technia.Presentation.DTOs;
using Technia.Presentation.Services.Interfaces;

namespace Technia.Presentation.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherBusiness _teacherBusiness;
        private readonly IMapper _mapper;

        public TeacherService(ITeacherBusiness teacherBusiness, IMapper mapper)
        {
            _teacherBusiness = teacherBusiness;
            _mapper = mapper;
        }

        public List<TeacherDto> GetTeachers()
        {
            var data = _teacherBusiness.GetTeachers();

            var dataMapped = _mapper.Map<List<TeacherDto>>(data);
            return dataMapped;
        }

        public TeacherDto SearchTeacherByFullName(string firstName, string lastName)
        {
            var data = _teacherBusiness.SearchTeacherByFullName(firstName, lastName);

            var dataMapped = _mapper.Map<TeacherDto>(data);

            return dataMapped;
        }

        public void UpdateTeacher(TeacherDto teacher, string firstName, string lastName)
        {
            var model = _mapper.Map<Teacher>(teacher);
            _teacherBusiness.UpdateTeacher(model, firstName, lastName);
        }

        public void SaveTeacher(TeacherDto teacher)
        {
            var model = _mapper.Map<Teacher>(teacher);
            _teacherBusiness.SaveTeacher(model);
        }
    }
}