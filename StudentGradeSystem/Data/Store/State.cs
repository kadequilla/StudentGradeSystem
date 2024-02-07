using StudentGradeSystem.Data.Model;

namespace StudentGradeSystem.Data.Store
{
    internal class State
    {
        public int MenuId { get; set; }
        public int? TotalStudentCount { get; set; }
        public List<Student> Students { get; set; } = [];
    }
}
