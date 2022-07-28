using Technia.Business.Models;

namespace Technia.Presentation.DTOs
{
    public class TeacherDto : PersonDto
    {
        public List<string?> TeachingSubjects { get; set; }
        public decimal Salary { get; set; }
        public string? Position { get; set; }
    }
}