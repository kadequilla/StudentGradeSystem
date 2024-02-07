using StudentGradeSystem.Data.Model;
using StudentGradeSystem.Data.Store;

namespace StudentGradeSystem.Sections
{
    internal class EnrollStudent : SectionBase
    {

        public override void View(State state)
        {
            int numStudent = 0;
            bool isContinue = true;

            Console.Clear();
            Println("\nEnroll Student");
            while (isContinue)
            {
                numStudent++;
                if (numStudent > state.TotalStudentCount)
                {
                    Console.Clear();
                    Println("Error: Cannot exceed total number of students!");
                    SetState(state);
                    PushSection(Menu.MenuSection);
                    break;
                }
                else
                {
                    Print("Enter student name: ");
                    string name = Console.ReadLine()!;
                    state.Students.Add(new Student(numStudent, name));
                    isContinue = IsEnterAgain();
                }
            }

            Console.Clear();
            SetState(state);
            PushSection(Menu.MenuSection);
        }
    }
}
