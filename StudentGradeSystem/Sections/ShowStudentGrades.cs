using StudentGradeSystem.Data.Model;
using StudentGradeSystem.Data.Store;

namespace StudentGradeSystem.Sections
{
    internal class ShowStudentGrades : SectionBase
    {
        public override void View(State state)
        {
            Console.Clear();
            Println("Student Grades");
            string[] cols = ["Name", "Science", "Math", "English", "Ave."];

            //display columns
            foreach (var c in cols) { Print($"{c}{Space(c)}"); }
            Print("\n");

            //display data/value/table data
            //Time complexity 0(n^2)
            foreach (var s in state.Students)
            {
                StudentGrades = s.StudentGrades;
                int[] grades = [GetGradeBySubj(Subject.Science), GetGradeBySubj(Subject.Math), GetGradeBySubj(Subject.English)];
                double ave = GetAve(grades);

                Print($"{s.Name}{Space(s.Name)}" +
                    $"{grades[0]}{Space(grades[0])}" +
                    $"{grades[1]}{Space(grades[1])}" +
                    $"{grades[2]}{Space(grades[2])}" +
                    $"{Math.Round(ave, 2)}{Space("")}\n");
            }

            SetState(state);

            if (IsGoBackMenu())
            {
                Console.Clear();
                PushSection(Menu.MenuSection);
            }
        }

    }
}

