using Newtonsoft.Json;
using Technia.Business.Models;
using Technia.Business.Repositories;
using static Technia.Infrastructure.Configuration.DataConfig;

namespace Technia.Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        public List<Teacher> GetTeachers()
        {
            var jsonResponse = File.ReadAllText(PathJsonTeacher);
            return JsonConvert.DeserializeObject<List<Teacher>>(jsonResponse) ?? new List<Teacher>();
        }

        public Teacher SearchTeacherByFullName(string firstName, string lastName)
        {
            var teachers = GetTeachers();

            var teacher = teachers.FirstOrDefault(x =>
                x.FirstName.ToLower().Equals(firstName.ToLower()) &&
                x.LastName.ToLower().Equals(lastName.ToLower()));

            return teacher ?? new Teacher();
        }

        public void UpdateTeacher(Teacher model, string firstName, string lastName)
        {
            var teachers = GetTeachers();

            foreach (var teacher in teachers)
            {
                if (teacher.FirstName.ToLower().Equals(firstName.ToLower()) &&
                    teacher.LastName.ToLower().Equals(lastName.ToLower()))
                {
                    teacher.FirstName = model.FirstName;
                    teacher.LastName = model.LastName;
                }
            }

            string jsonToWrite = JsonConvert.SerializeObject(teachers);
            File.WriteAllText(PathJsonTeacher, jsonToWrite);
        }

        public void SaveTeacher(Teacher teacher)
        {
            var jsonResponse = File.ReadAllText(PathJsonTeacher);

            var teachers = JsonConvert.DeserializeObject<List<Teacher>>(jsonResponse) ?? new List<Teacher>();

            teachers.Add(teacher);

            string jsonToWrite = JsonConvert.SerializeObject(teachers);
            File.WriteAllText(PathJsonTeacher, jsonToWrite);
        }
    }
}