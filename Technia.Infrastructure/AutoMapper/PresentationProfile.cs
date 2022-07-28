using AutoMapper;
using Technia.Business.Models;
using Technia.Presentation.DTOs;

namespace Technia.Infrastructure.AutoMapper
{
    public class PresentationProfile : Profile
    {
        public PresentationProfile()
        {
            CreateMap<GradeDto, Grade>().ReverseMap();
            CreateMap<PersonDto, Person>().ReverseMap();
            CreateMap<StudentDto, Student>().ReverseMap();
            CreateMap<TeacherDto, Teacher>().ReverseMap();
        }
    }
}