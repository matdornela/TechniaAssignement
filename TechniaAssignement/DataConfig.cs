namespace TechniaAssignement
{
    public class DataConfig
    {
        public static string PathBase => AppContext.BaseDirectory.ToLower().Replace("\\bin\\debug\\net6.0\\", "");
        public static string PathJsonStudent => Path.Combine(PathBase, "DataSource/Student.json");
        public static string PathJsonTeacher => Path.Combine(PathBase, "DataSource/Teacher.json");
        public static string PathJsonSubject => Path.Combine(PathBase, "DataSource/Subject.json");
    }
}