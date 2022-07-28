using Newtonsoft.Json;
using Technia.Business.Models;
using Technia.Business.Repositories;
using static Technia.Infrastructure.Configuration.DataConfig;

namespace Technia.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public List<Student> GetStudents()
        {
            var jsonResponse = File.ReadAllText(PathJsonStudent);
            return JsonConvert.DeserializeObject<List<Student>>(jsonResponse) ?? new List<Student>();
        }

        public Student SearchStudentByFullName(string firstName, string lastName)
        {
            var students = GetStudents();

            var student = students.FirstOrDefault(x =>
                x.FirstName.ToLower().Equals(firstName.ToLower()) &&
                x.LastName.ToLower().Equals(lastName.ToLower()));

            return student ?? new Student();
        }

        public void UpdateStudent(Student model, string firstName, string lastName)
        {
            var students = GetStudents();

            foreach (var student in students)
            {
                if (student.FirstName.ToLower().Equals(firstName.ToLower()) &&
                    student.LastName.ToLower().Equals(lastName.ToLower()))
                {
                    student.FirstName = model.FirstName;
                    student.LastName = model.LastName;
                }
            }

            string jsonToWrite = JsonConvert.SerializeObject(students);
            File.WriteAllText(PathJsonStudent, jsonToWrite);
        }

        public void SaveStudent(Student student)
        {
            var jsonResponse = File.ReadAllText(PathJsonStudent);

            var students = JsonConvert.DeserializeObject<List<Student>>(jsonResponse) ?? new List<Student>();

            students.Add(student);

            string jsonToWrite = JsonConvert.SerializeObject(students);
            File.WriteAllText(PathJsonStudent, jsonToWrite);
        }
    }
}