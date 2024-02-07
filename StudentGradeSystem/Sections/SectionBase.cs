using StudentGradeSystem.Data.Model;
using StudentGradeSystem.Data.Store;

namespace StudentGradeSystem.Sections
{
    internal abstract class SectionBase
    {

        public State state = new();
        public abstract void View(State state);

        public const string STRING_ENTER_AGAIN = "Enter Again[Y/N]:";
        public enum Menu
        {
            MenuSection,
            Enroll,
            CreateGrade,
            ViewGrades,
            ViewTop
        }

        public void SetState(State newState)
        {
            state = newState;
        }


        public void PushSection()
        {
            if (state.MenuId == 1)
            {
                new EnrollStudent().View(state);
            }
            else if (state.MenuId == 2)
            {
                new EnterStudentGrades().View(state);
            }
            else if (state.MenuId == 3)
            {
                new ShowStudentGrades().View(state);
            }
            else if (state.MenuId == 4)
            {
                new ShowTopStudent().View(state);
            }


        }

        public void PushSection(Menu menu)
        {

            if (menu == Menu.MenuSection)
            {
                new MenuSection().View(state);
            }
            else if (menu == Menu.Enroll)
            {
                new EnrollStudent().View(state);
            }
            else if (menu == Menu.CreateGrade)
            {
                new EnterStudentGrades().View(state);
            }
            else if (menu == Menu.ViewGrades)
            {
                new ShowStudentGrades().View(state);
            }
            else if (menu == Menu.ViewTop)
            {
                new ShowTopStudent().View(state);
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

        public List<StudentGrade> StudentGrades = [];
        public int GetGradeBySubj(Subject subject)
        {
            StudentGrade? studentGrade = StudentGrades.FirstOrDefault(val => val.Subject == subject);
            return studentGrade == null ? 0 : studentGrade.Grade;
        }

        public static void Print(dynamic s)
        {
            Console.Write(s);
        }

        public static void Println(dynamic s)
        {
            Console.WriteLine(s);
        }

        public static string Space(string s)
        {
            string res = "";
            for (int i = 0; i <= 20 - (s.Length); i++)
            {
                res += " ";
            }
            return res;
        }

        public static string Space(int g)
        {
            string res = "";
            for (int i = 0; i <= 20 - (g.ToString().Length); i++)
            {
                res += " ";
            }
            return res;
        }

        public static double GetAve(int[] grades)
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
