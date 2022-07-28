using Microsoft.Extensions.DependencyInjection;
using Technia.Business;
using Technia.Business.Interfaces;
using Technia.Business.Repositories;
using Technia.Infrastructure.AutoMapper;
using Technia.Infrastructure.Repositories;
using Technia.Presentation.DTOs;
using Technia.Presentation.Services;
using Technia.Presentation.Services.Interfaces;

namespace TechniaAssignement
{
    public class Program
    {
        private static IServiceProvider _provider;
        private static IStudentService _studentService;
        private static ITeacherService _teacherService;

        private static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddAutoMapper(typeof(PresentationProfile));
            services.AddSingleton<ITeacherRepository, TeacherRepository>();
            services.AddSingleton<ITeacherBusiness, TeacherBusiness>();
            services.AddSingleton<ITeacherService, TeacherService>();
            services.AddSingleton<IStudentRepository, StudentRepository>();
            services.AddSingleton<IStudentBusiness, StudentBusiness>();
            services.AddSingleton<IStudentService, StudentService>();
            _provider = services.BuildServiceProvider();
            _studentService = _provider.GetService<IStudentService>();
            _teacherService = _provider.GetService<ITeacherService>();

            ShowMenu();
        }

        private static void ShowMenu()
        {
            bool finished = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Create Student");
                Console.WriteLine("2. Search Student");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Create Teacher");
                Console.WriteLine("5. Search Teacher");
                Console.WriteLine("6. Update Teacher");
                Console.WriteLine("7. Exit");
                Console.WriteLine("\r\nSelect an option");

                switch (Console.ReadLine())
                {
                    case "1":
                        CreateStudent();
                        break;

                    case "2":
                        SearchStudent();
                        break;

                    case "3":
                        UpdateStudent();
                        break;

                    case "4":
                        CreateTeacher();
                        break;

                    case "5":
                        SearchTeacher();
                        break;

                    case "6":
                        UpdateTeacher();
                        break;

                    case "7":
                        Environment.Exit(0);
                        break;
                }

                if (PromptConfirmation("Would you like to do anything else?"))
                {
                    finished = false;
                }
                else
                {
                    finished = true;
                }
            } while (!finished);
        }

        private static void SearchStudent()
        {
            var firstName = GetInput("Type the First Name");

            var lastName = GetInput("Type the Last Name");

            var student = _studentService.SearchStudentByFullName(firstName, lastName);

            if (!string.IsNullOrEmpty(student.FirstName))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }
            else
                Console.WriteLine("Student not found");
        }

        private static void SearchTeacher()
        {
            var firstName = GetInput("Type the First Name");
            var lastName = GetInput("Type the Last Name");

            var teacher = _teacherService.SearchTeacherByFullName(firstName, lastName);

            if (!string.IsNullOrEmpty(teacher.FirstName))
            {
                Console.WriteLine($"{teacher.FirstName} {teacher.LastName}");
            }
            else
                Console.WriteLine("Teacher not found");
        }

        private static void UpdateTeacher()
        {
            var firstName = GetInput("Type the First Name");
            var lastName = GetInput("Type the Last Name");

            var teacher = _teacherService.SearchTeacherByFullName(firstName, lastName);

            if (PromptConfirmation("Would like to update her/his first name?"))
            {
                teacher.FirstName = GetInput("Type the First Name"); ;
            }
            if (PromptConfirmation("Would like to update her/his last name?"))
            {
                teacher.LastName = GetInput("Type the Last Name"); ;
            }

            _teacherService.UpdateTeacher(teacher, firstName, lastName);
        }

        private static void UpdateStudent()
        {
            var firstName = GetInput("Type the First Name");
            var lastName = GetInput("Type the Last Name");

            var student = _studentService.SearchStudentByFullName(firstName, lastName);

            if (PromptConfirmation("Would like to update her/his first name?"))
            {
                student.FirstName = GetInput("Type the First Name"); ;
            }
            if (PromptConfirmation("Would like to update her/his last name?"))
            {
                student.LastName = GetInput("Type the Last Name"); ;
            }

            _studentService.UpdateStudent(student, firstName, lastName);
        }

        private static void CreateStudent()
        {
            var student = new StudentDto
            {
                FirstName = GetInput("Type the First Name"),
                LastName = GetInput("Type the Last Name")
            };

            var grades = new List<GradeDto>();

            if (PromptConfirmation("Would you like to inform the grades?"))
            {
                bool finished = false;

                while (!finished)
                {
                    var grade = new GradeDto
                    {
                        Value = Convert.ToDouble(GetInput("Grade")),
                        Subject = GetInput("Subject"),
                        Observation = GetInput("Observation")
                    };

                    grades.Add(grade);

                    var response = GetInput("Type Y to register more grades or N to exit");

                    if (response.ToLower() == "n")
                    {
                        finished = true;
                    }
                }

                student.Grades = grades;
            }

            _studentService.SaveStudent(student);
        }

        private static void CreateTeacher()
        {
            var teacher = new TeacherDto
            {
                FirstName = GetInput("Type the First Name"),
                LastName = GetInput("Type the Last Name"),
                Position = GetInput("Type the Position"),
                Salary = Convert.ToDecimal(GetInput("Type the current salary"))
            };

            if (PromptConfirmation("Would you like to inform the teaching subjects?"))
            {
                bool finished = false;

                List<string?> teachingSubjects = new List<string?>(); ;

                while (!finished)
                {
                    var subject = GetInput("Subject");
                    teachingSubjects.Add(subject);

                    var response = GetInput("Type Y to register more subjects or N to exit");

                    if (response.ToLower() == "n")
                    {
                        finished = true;
                    }
                }

                teacher.TeachingSubjects = teachingSubjects;
            }

            _teacherService.SaveTeacher(teacher);
        }

        private static string? GetInput(string prompt)
        {
            string? result = "";
            do
            {
                Console.WriteLine(prompt);
                result = Console.ReadLine();
                if (string.IsNullOrEmpty(result))
                {
                    Console.WriteLine("Empty input, please try again");
                }
            } while (string.IsNullOrEmpty(result));
            return result;
        }

        private static bool PromptConfirmation(string confirmText)
        {
            Console.Write(confirmText + " [y/n] : ");
            ConsoleKey response = Console.ReadKey(false).Key;
            Console.WriteLine();
            return response == ConsoleKey.Y;
        }
    }
}