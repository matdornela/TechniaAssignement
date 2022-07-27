namespace TechniaAssignement.Models
{
    public class Teacher : Person
    {
        public List<string?> TeachingSubjects { get; set; }
        public decimal Salary { get; set; }
        public string? Position { get; set; }
    }
}