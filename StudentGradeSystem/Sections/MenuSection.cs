using StudentGradeSystem.Data.Store;

namespace StudentGradeSystem.Sections
{
    internal class MenuSection : SectionBase
    {

        public override void View(State state)
        {
            Console.Clear();
            if (state.TotalStudentCount is null)
            {
                Console.Write("Enter total students: ");
                state.TotalStudentCount = InputInteger("Enter total students: ", int.MaxValue);
            }


            Println("\n" +
                "Welcome to the Student Grades System!\r\n" +
                "[1] Enroll Students\r\n" +
                "[2] Enter Student Grades\r\n" +
                "[3] Show Student Grades\r\n" +
                "[4] Show Top Student\r\n" +
                "[5] Exit");

            Print("Enter Choice: ");
            state.MenuId = InputInteger("Enter choice: ", 5);


            SetState(state);
            PushSectionBySelectedMenu();
        }

        private int InputInteger(string text, int max)
        {
            int num;
            while (!int.TryParse(Console.ReadLine(), out num) || num > max)
            {
                Print(text);
            }
            return num;
        }


    }
}
