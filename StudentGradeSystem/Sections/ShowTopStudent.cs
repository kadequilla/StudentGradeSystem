using StudentGradeSystem.Data.Model;
using StudentGradeSystem.Data.Store;

namespace StudentGradeSystem.Sections
{
    internal class ShowTopStudent : SectionBase
    {
        public override void View(State state)
        {
            Console.Clear();
            double ave = 0.0;
            Student? topStudent = null;

            foreach (var s in state.Students)
            {
                StudentGrades = s.StudentGrades;
                int[] grades = [GetGradeBySubj(Subject.Science), GetGradeBySubj(Subject.Math), GetGradeBySubj(Subject.English)];
                if (GetAve(grades) > ave)
                {
                    ave = GetAve(grades);
                    topStudent = s;
                }
            }

            Println($"Top Student: {topStudent?.Name}");

            SetState(state);

            if (IsGoBackMenu())
            {
                Console.Clear();
                PushSection(Menu.MenuSection);
            }

        }
    }
}

