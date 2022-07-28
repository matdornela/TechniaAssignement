namespace Technia.Infrastructure.Configuration
{
    public class DataConfig
    {
        public static string PathBase => "C:\\Projects\\Technia\\TechniaAssignement\\Technia.Infrastructure\\";
        public static string PathJsonStudent => Path.Combine(PathBase, "DataSource/Student.json");
        public static string PathJsonTeacher => Path.Combine(PathBase, "DataSource/Teacher.json");
    }
}