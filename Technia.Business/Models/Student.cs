namespace Technia.Business.Models
{
    public class Student : Person
    {
        public List<Grade> Grades { get; set; }
    }
}