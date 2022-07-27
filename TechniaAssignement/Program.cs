using TechniaAssignement.Models;

namespace TechniaAssignement;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        ShowMenu();
    }

    private static bool ShowMenu()
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
                return false;

            case "2":
                SearchStudent();
                return false;

            case "3":
                UpdateStudent();
                return false;

            case "4":
                CreateTeacher();
                return false;

            case "5":
                SearchTeacher();
                return false;

            case "6":
                UpdateTeacher();
                return false;

            case "7":
                return false;

            default:
                return true;
        }
    }

    private static void SearchStudent()
    {
        DataServiceJson dataServiceJson = new DataServiceJson();
        var firstName = GetInput("Type the First Name");
        var lastName = GetInput("Type the Last Name");

        var student = dataServiceJson.SearchStudentByFullName(firstName, lastName);

        if (student != null)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
        else
            Console.WriteLine("Student not found");
    }

    private static void SearchTeacher()
    {
        DataServiceJson dataServiceJson = new DataServiceJson();
        var firstName = GetInput("Type the First Name");
        var lastName = GetInput("Type the Last Name");

        var teacher = dataServiceJson.SearchTeacherByFullName(firstName, lastName);

        if (teacher != null)
        {
            Console.WriteLine($"{teacher.FirstName} {teacher.LastName}");
        }
        else
            Console.WriteLine("Teacher not found");
    }

    private static void UpdateTeacher()
    {
        DataServiceJson dataServiceJson = new DataServiceJson();
        var firstName = GetInput("Type the First Name");
        var lastName = GetInput("Type the Last Name");

        var teacher = dataServiceJson.SearchTeacherByFullName(firstName, lastName);

        if (PromptConfirmation("Would like to update the first student name?"))
        {
            teacher.FirstName = GetInput("Type the First Name"); ;
        }
        if (PromptConfirmation("Would like to update the last student name?"))
        {
            teacher.LastName = GetInput("Type the Last Name"); ;
        }

        dataServiceJson.UpdateTeacher(teacher, firstName, lastName);
    }

    private static void UpdateStudent()
    {
        DataServiceJson dataServiceJson = new DataServiceJson();
        var firstName = GetInput("Type the First Name");
        var lastName = GetInput("Type the Last Name");

        var student = dataServiceJson.SearchStudentByFullName(firstName, lastName);

        if (PromptConfirmation("Would like to update the first student name?"))
        {
            student.FirstName = GetInput("Type the First Name"); ;
        }
        if (PromptConfirmation("Would like to update the last student name?"))
        {
            student.LastName = GetInput("Type the Last Name"); ;
        }

        dataServiceJson.UpdateStudent(student, firstName, lastName);
    }

    private static void CreateStudent()
    {
        var student = new Student
        {
            FirstName = GetInput("Type the First Name"),
            LastName = GetInput("Type the Last Name")
        };

        var grades = new List<Grade>();
        var grade = new Grade();

        if (PromptConfirmation("Would you like to inform the grades?"))
        {
            bool executingLoop = true;

            while (executingLoop)
            {
                grade.Value = Convert.ToDouble(GetInput("Grade"));
                grade.Subject = GetInput("Subject");
                grade.Observation = GetInput("Observation");

                grades.Add(grade);

                var response = GetInput("Type Y to register more grades or N to exit");

                if (response.ToLower() == "n")
                {
                    executingLoop = false;
                }
            }

            student.Grades = grades;
        }

        DataServiceJson dataServiceJson = new DataServiceJson();
        dataServiceJson.SaveStudent(student);
    }

    private static void CreateTeacher()
    {
        var teacher = new Teacher
        {
            FirstName = GetInput("Type the First Name"),
            LastName = GetInput("Type the Last Name"),
            Position = GetInput("Type the Position"),
            Salary = Convert.ToDecimal(GetInput("Type the current salary"))
        };

        var teachingSubjects = new List<string?>();

        if (PromptConfirmation("Would you like to inform the teaching subjects?"))
        {
            bool executingLoop = true;

            while (executingLoop)
            {
                teachingSubjects.Add(GetInput("Subject"));

                var response = GetInput("Type Y to register more grades or N to exit");

                if (response.ToLower() == "n")
                {
                    executingLoop = false;
                }
            }

            teacher.TeachingSubjects = teachingSubjects;
        }

        DataServiceJson dataServiceJson = new DataServiceJson();
        dataServiceJson.SaveTeacher(teacher);
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