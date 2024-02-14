using StudentGradeSystem.Data.Model;
using StudentGradeSystem.Data.Store;

namespace StudentGradeSystem.Sections
{
    internal class EnterStudentGrades : SectionBase
    {
        public override void View(State state)
        {
            Console.Clear();
            int count = 0;
            if (state.Students.Count == 0)
            {
                Println("Students not found!");
                SetState(state);
                PushSection(Menu.MenuSection);
            }
            else
            {
                Println("Enter Student Grades\n");
                foreach (var student in state.Students)
                {
                    count++;
                    Println($"Student: {student.Name}");
                    foreach (Subject subj in Enum.GetValues(typeof(Subject)))
                    {
                        Print($"Enter grade for {subj}: ");
                        int grade = 0;

                        while (!int.TryParse(Console.ReadLine(), out grade))
                        {
                            Print($"Enter grade for {subj}: ");
                        }

                        student.StudentGrades.Add(new StudentGrade(student, subj, grade));
                    }

                    SetState(state);
                    if (!IsEnterAgain()) break;
                }
            }
            Console.Clear();
            if (count == state.Students.Count)
            {
                Println("All done!");
            }

            PushSection(Menu.MenuSection);
        }
    }
}
