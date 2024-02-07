using StudentGradeSystem.Data.Model;
using StudentGradeSystem.Data.Store;

namespace StudentGradeSystem.Sections
{
    internal class EnterStudentGrades : SectionBase
    {
        public override void View(State state)
        {
            Console.Clear();
            if (state.Students.Count == 0)
            {
                Println("Students not found!");
                SetState(state);
                PushSectionMenu(Menu.MenuSection);
            }
            else
            {
                Println("Enter Student Grades\n");
                foreach (var student in state.Students)
                {
                    foreach (Subject subj in Enum.GetValues(typeof(Subject)))
                    {
                        Println(subj);
                    }

                }
            }


        }
    }
}
