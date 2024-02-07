using StudentGradeSystem.Data.Store;

namespace StudentGradeSystem.Sections
{
    internal abstract class SectionBase
    {

        public State state = new();

        public abstract void View(State state);

        public const string STRING_ENTER_AGAIN = "Enter Again[Y/N]:";


        public void PushSectionBySelectedMenu()
        {
            if (state.MenuId == 1)
            {
                new EnrollStudent().View(state);
            }
            else if (state.MenuId == 2)
            {
                new EnterStudentGrades().View(state);
            }

        }

        public void PushSectionMenu(Menu menu)
        {

            if (menu == Menu.MenuSection)
            {
                new MenuSection().View(state);
            }
            if (menu == Menu.Enroll)
            {
                new EnterStudentGrades().View(state);
            }
        }

        public static bool IsEnterAgain()
        {
            Console.WriteLine(STRING_ENTER_AGAIN);
            string again = Console.ReadLine()!;
            while (again != "n" && again != "y")
            {
                Console.WriteLine(STRING_ENTER_AGAIN);
                again = Console.ReadLine()!;
            }

            return !(again.Equals("n", StringComparison.CurrentCultureIgnoreCase));
        }


        public void SetState(State newState)
        {
            state = newState;
        }

        public enum Menu
        {
            MenuSection,
            Enroll,
            CreateGrade,
            ViewGrades,
            ViewTop
        }

        public static void Print(dynamic s)
        {
            Console.Write(s);
        }

        public static void Println(dynamic s)
        {
            Console.WriteLine(s);
        }
    }
}
