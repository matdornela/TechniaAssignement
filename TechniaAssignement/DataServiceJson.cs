using Newtonsoft.Json;
using TechniaAssignement.Models;

namespace TechniaAssignement
{
    public class DataServiceJson
    {
        public List<Student> GetStudents()
        {
            var jsonResponse = File.ReadAllText(DataConfig.PathJsonStudent);
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
            File.WriteAllText(DataConfig.PathJsonStudent, jsonToWrite);
        }

        public void SaveStudent(Student student)
        {
            var jsonResponse = File.ReadAllText(DataConfig.PathJsonStudent);

            var students = JsonConvert.DeserializeObject<List<Student>>(jsonResponse) ?? new List<Student>();

            students.Add(student);

            string jsonToWrite = JsonConvert.SerializeObject(students);
            File.WriteAllText(DataConfig.PathJsonStudent, jsonToWrite);
        }

        public List<Teacher> GetTeachers()
        {
            var jsonResponse = File.ReadAllText(DataConfig.PathJsonTeacher);
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
            File.WriteAllText(DataConfig.PathJsonTeacher, jsonToWrite);
        }

        public void SaveTeacher(Teacher teacher)
        {
            var jsonResponse = File.ReadAllText(DataConfig.PathJsonTeacher);

            var teachers = JsonConvert.DeserializeObject<List<Teacher>>(jsonResponse) ?? new List<Teacher>();

            teachers.Add(teacher);

            string jsonToWrite = JsonConvert.SerializeObject(teachers);
            File.WriteAllText(DataConfig.PathJsonTeacher, jsonToWrite);
        }
    }
}