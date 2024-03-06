using StudentGradeSystem.Data.Model;
using StudentGradeSystem.Data.Store;

namespace StudentGradeSystem.Sections
{
    internal abstract class SectionBase
    {
        private State _state = new();
        public abstract void View(State state);

        private const string StringEnterAgain = "Enter Again[Y/N]:";

        protected enum Menu
        {
            MenuSection,
            Enroll,
            CreateGrade,
            ViewGrades,
            ViewTop
        }

        protected void SetState(State newState)
        {
            _state = newState;
        }


        protected void PushSection()
        {
            if (_state.MenuId == 1)
            {
                new EnrollStudent().View(_state);
            }
            else if (_state.MenuId == 2)
            {
                new EnterStudentGrades().View(_state);
            }
            else if (_state.MenuId == 3)
            {
                new ShowStudentGrades().View(_state);
            }
            else if (_state.MenuId == 4)
            {
                new ShowTopStudent().View(_state);
            }
        }

        protected void PushSection(Menu menu)
        {
            if (menu == Menu.MenuSection)
            {
                new MenuSection().View(_state);
            }
            else if (menu == Menu.Enroll)
            {
                new EnrollStudent().View(_state);
            }
            else if (menu == Menu.CreateGrade)
            {
                new EnterStudentGrades().View(_state);
            }
            else if (menu == Menu.ViewGrades)
            {
                new ShowStudentGrades().View(_state);
            }
            else if (menu == Menu.ViewTop)
            {
                new ShowTopStudent().View(_state);
            }
        }

        protected static bool IsEnterAgain()
        {
            Console.WriteLine(StringEnterAgain);
            string again = Console.ReadLine()!;
            while (again != "n" && again != "y")
            {
                Console.WriteLine(StringEnterAgain);
                again = Console.ReadLine()!;
            }

            return !(again.Equals("n", StringComparison.CurrentCultureIgnoreCase));
        }

        protected List<StudentGrade> StudentGrades = [];

        protected int GetGradeBySubj(Subject subject)
        {
            var studentGrade = StudentGrades.FirstOrDefault(val => val.Subject == subject);
            return studentGrade?.Grade ?? 0;
        }

        protected static void Print(dynamic s) => Console.Write(s);

        protected static void Println(dynamic s) => Console.WriteLine(s);

        protected static string Space(string s)
        {
            var res = "";
            for (var i = 0; i <= 20 - (s.Length); i++)
            {
                res += " ";
            }

            return res;
        }

        protected static string Space(int g)
        {
            string res = "";
            for (int i = 0; i <= 20 - (g.ToString().Length); i++)
            {
                res += " ";
            }

            return res;
        }

        protected static double GetAve(int[] grades)
        {
            double sum = 0;
            foreach (var g in grades)
            {
                sum += g;
            }

            return sum / grades.Length;
        }

        public static bool IsGoBackMenu()
        {
            Print("\n\nPress [0] to go back menu and press any key to exit: ");
            return Console.ReadLine() == "0";
        }
    }
}