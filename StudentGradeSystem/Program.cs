using StudentGradeSystem.Data.Store;
using StudentGradeSystem.Sections;

namespace StudentGradeSystem
{
    public class StudentGradeSystem
    {
        public static void Main(string[] args)
        {
            new MenuSection().View(new State());
        }
    }
}