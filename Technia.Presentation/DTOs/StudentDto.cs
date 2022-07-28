using Technia.Business.Models;

namespace Technia.Presentation.DTOs
{
    public class StudentDto : PersonDto
    {
        public List<GradeDto> Grades { get; set; }
    }
}