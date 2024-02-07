namespace StudentGradeSystem.Data.Model
{
    internal class StudentGrade
    {
        public Student? Student { get; set; }
        public Subject Subject { get; set; }
        public int Grade { get; set; }

        public StudentGrade(Student? student, Subject subject, int grade)
        {
            Student = student;
            Subject = subject;
            Grade = grade;
        }
    }
}
