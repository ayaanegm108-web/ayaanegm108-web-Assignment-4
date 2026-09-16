using Ass04.Benchmarks;
using BenchmarkDotNet.Running;
using static System.Collections.Specialized.BitVector32;
using System.Text;
namespace Ass04
{
    internal class Program
    {

        #region Part 1 — Starter Data

        static string[] sessionNames ={
                "C# Basics",
                "Arrays",
                "Functions",
                "Date and Time",
                "Exception Handling"
            };

        static DateTime[] sessionDates =
         {
                new DateTime(2026, 9, 10, 18, 0, 0),
                new DateTime(2026, 9, 13, 18, 0, 0),
                new DateTime(2026, 9, 17, 18, 0, 0),
                new DateTime(2026, 9, 20, 18, 0, 0),
                new DateTime(2026, 9, 24, 18, 0, 0)
            };

        static int[] sessionDurations =
         {
                180,
                240,
                180,
                240,
                180
            };
        public static void displayArray<T>(T[] arr)

        {
            Console.Write("[");
            for (int i = 0; i < arr.Length; i++)
            {
                if (i != 0)
                {
                    Console.Write(" ,");
                }
                Console.Write(arr[i]);
            }
            Console.Write("]\n");
        }
        #endregion

        #region Part 2 — Display All Sessions

        public static void displaySessions()
        {
            int size = sessionNames.Length;
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"{i + 1}. {sessionNames[i]}");
                Console.WriteLine($"Start Time: {sessionDates[i].ToString("dd MMMM yyyy")} ");
                //Console.WriteLine($"Date:       {sessionDates[i].Day} {sessionDates[i].Month} {sessionDates[i].Year}");
                Console.WriteLine($"Start Time: {sessionDates[i].ToString("hh:mm tt")}");
                //Console.WriteLine($"Start Time: {sessionDates[i].Hour}:{sessionDates[i].Minute} {sessionDates[i].}");
                Console.WriteLine($"Duration:   {sessionDurations[i]} minutes");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        #endregion

        #region Part 3 — Search for a Session 

        public static void displayOneSession(int index)
        {
            Console.WriteLine($"{index + 1}. {sessionNames[index]}");
            Console.WriteLine($"Start Time: {sessionDates[index].ToString("dd MMMM yyyy")} ");
            //Console.WriteLine($"Date:       {sessionDates[index].Day} {sessionDates[index].Month} {sessionDates[index].Year}");
            Console.WriteLine($"Start Time: {sessionDates[index].ToString("hh:mm tt")}");
            //Console.WriteLine($"Start Time: {sessionDates[index].Hour}:{sessionDates[index].Minute} {sessionDates[index].}");
            Console.WriteLine($"Duration:   {sessionDurations[index]} minutes");
            Console.WriteLine();
        }
        public static string validateInputstring()
        {
            string name = null!;

            while (string.IsNullOrEmpty(name))
            {

                Console.Write("session name: ");
                name = Console.ReadLine()!;

                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("no input provided ");
                }


            }

            return name;
        }
        public static int searchSession()
        {
            string name = validateInputstring();
            int index = searchStringIgnoreCase(name);
            displayOneSession(index);
            return index;



        }

        public static int searchStringIgnoreCase(string name)
        {

            int index = Array.FindIndex
                (sessionNames, n => n.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (index >= 0)
            {
                Console.WriteLine($"Session found");

            }
            else
            {
                Console.WriteLine("Session not found.");
            }
            return index;
        }
        #endregion

        #region Part 4 — Array Methods Practice
        // 4.1
        public static void sortSessionNames()
        {
            string[] copyArr = new string[sessionNames.Length];
            Array.Copy(sessionNames, copyArr, sessionNames.Length);
            Array.Sort(copyArr);
            Console.Write("Session names sorted in ascending order: ");
            displayArray(copyArr);
        }

        // 4.2
        public static void ReverseSessionNames()
        {
            string[] copyArr = new string[sessionNames.Length];
            Array.Copy(sessionNames, copyArr, sessionNames.Length);
            Array.Reverse(copyArr);
            Console.Write("Session names in reverse order:");
            displayArray(copyArr);
        }

        //4.3
        public static void FindSessionIndex()
        {
            //Handlindg case sensitivity
            string name = validateInputstring().ToLower();
            string[] lowerCaseSessionNames = Array.ConvertAll(sessionNames, s => s.ToLower());


            int index = Array.IndexOf(lowerCaseSessionNames, name);
            Console.WriteLine($"Index of session '{name}': {index}");
        }

        // 4.4
        public static void CheckIfASessionExists()
        {
            string name = validateInputstring();
            bool exists = Array.Exists(sessionNames, s => s.Equals(name, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine((exists) ? $"Session '{name}' exists." : $"Session '{name}' does not exist.");
        }

        //4.5  Find a Session
        public static string FindASessionUsingACondition(Func<string, bool> condition)
        {

            foreach (string session in sessionNames)
            {
                if (condition(session))
                {
                    Console.WriteLine($"Session found : {session}");

                    return session;
                }

            }
            Console.WriteLine("Session not found.");

            return null!;
        }

        //4.6  
        public static void FindASessionIndexUsingACondition(Func<string, bool> condition)
        {
            int index;
            string session = FindASessionUsingACondition(condition);
            if (session != null)
            {
                index = Array.IndexOf(sessionNames, session);
                Console.WriteLine($"The index of the found session is: {index}");
            }
        }

        #endregion

        #region Part 5 — Duration Analysis
        public static void GetTotalDuration()
        {
            Console.WriteLine($"Total Duration: {sessionDurations.Sum()} minutes");
        }
        public static void GetAverageDuration()
        {
            Console.WriteLine($"Average Duration: {sessionDurations.Average()} minutes");
        }
        public static void GetShortestDuration()
        {
            Console.WriteLine($"Shortest Duration: {sessionDurations.Min()} minutes");
        }
        public static void GetLongestDuration()
        {
            Console.WriteLine($"Longest Duration: {sessionDurations.Max()} minutes");
        }



        public static void durationAnalysis()
        {

            GetTotalDuration();
            GetAverageDuration();
            GetShortestDuration();
            GetLongestDuration();

        }

        //=======================================
        public static void sortDuration()
        {
            int[] copyArr = new int[sessionDurations.Length];
            Array.Copy(sessionDurations, copyArr, sessionDurations.Length);
            copyArr.Sort();
            displayArray(copyArr);
        }
        #endregion
        #region Part 7 — ref, out, and Reference-Type Parameters
        public static void squareValue(ref int value)
        {
            int result = value * value;
            Console.WriteLine($"square value : {result}");
        }

        //=====================

        public static void sessionDetailsReturn(out int index, out int sessionDuration)

        {
            string name = validateInputstring();
            index = Array.FindIndex
                (sessionNames, n => n.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (index == -1)
            {
                Console.WriteLine("Session not found.");
                sessionDuration = 0;
            }
            else
            {
                sessionDuration = sessionDurations[index];
            }
        }
        //=======================
        public static void squareRoot(double value)
        {
            value = Math.Sqrt(value);
        }
        #endregion
        #region Part 8 — params Keyword
        public static int CalculateTotalDuration(params int[] durations)
        {
            return durations.Sum();
        }
        #endregion
        #region Part 9 — Session Date Details
        public static void displaySessionDate()
        {

            int index = -1;
            while (index == -1)
            {

                String name = validateInputstring();
                index = Array.FindIndex
               (sessionNames, n => n.Equals(name, StringComparison.OrdinalIgnoreCase));
                Console.WriteLine((index == -1) ? ("Session not found.") : ("Session found."));

            }


            Console.WriteLine($"Session: {sessionNames[index]}");
            Console.WriteLine($"Date : {sessionDates[index].ToString("dd MMMMMM yyyy")}");
            Console.WriteLine($"Day : {sessionDates[index].DayOfWeek}");
            Console.WriteLine($"Year : {sessionDates[index].Year}");
            Console.WriteLine($"Month : {sessionDates[index].Month}");
            Console.WriteLine($"Day Number : {sessionDates[index].Day}");
            Console.WriteLine($"Start Time: {sessionDates[index].ToString("hh:mm tt")}");
            Console.WriteLine($"Duration : {sessionDurations[index]}");
            Console.WriteLine($"End Time: {(sessionDates[index].AddMinutes(sessionDurations[index])).ToString("hh:mm tt")}");

        }
        #endregion
        #region Part 10 — Date Difference
        public static void findTimeDiff()
        {
            Console.WriteLine("Enter the 2 sessions you want to find difference between :");
            Console.Write("enter the first ");
            string session1 = validateInputstring();
            int index1 = searchStringIgnoreCase(session1);

            Console.WriteLine();

            Console.Write("enter the second ");
            string session2 = validateInputstring();
            int index2 = searchStringIgnoreCase(session2);
            if (index1 >= 0 && index2 >= 0)
            {
                TimeSpan diff = (sessionDates[index1] - sessionDates[index2]);
                diff = (sessionDates[index1] - sessionDates[index2]).Duration();

                Console.WriteLine($"\nDifferences :\n{diff.Days} days \n{diff.TotalHours} hours");
            }


        }

        #endregion
        #region Part 11 — Past and Upcoming Sessions
        public static void sessionsStatues()
        {
            //TimeSpan diff;
            for (int i = 0; i < sessionDates.Length; i++)
            {
                Console.WriteLine((sessionDates[i] > DateTime.Now) ? $"{sessionNames[i]}  Upcoming" : $"{sessionNames[i]} past");
            }
        }
        #endregion 
        #region Part 12 — Find the Next Session
        public static void findNextSession()
        {
            int i = 0;
            while (sessionDates[i] < DateTime.Now && i < sessionDates.Length)
            {
                i++;
            }
            if (sessionDates[i] > DateTime.Now)
            {
                TimeSpan diff = (DateTime.Now - sessionDates[i]).Duration();
                Console.WriteLine($"Next session : {sessionNames[i]} \n{sessionDates[i].ToString("dd MMMM yyyy")} \n{sessionDates[i].ToString("hh:mm tt")}");
                Console.WriteLine($"Time Remaining: \n{diff.Days} days \n{((int)diff.TotalHours)} hours");

            }
            else
            {
                Console.WriteLine("No up coming sessions");
            }

        }
        #endregion
        #region Part 13 — Date Formatting
        public static void displaySessionDateByAllFormat()
        {
            string name = validateInputstring();
            int index = Array.FindIndex
               (sessionNames, n => n.Equals(name, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(sessionDates[index].ToString("yyyy-MM-dd"));
            Console.WriteLine(sessionDates[index].ToString("dd/MM/yyyy"));
            Console.WriteLine(sessionDates[index].ToString("dd MMMM yyyy"));
            Console.WriteLine(sessionDates[index].ToString("dddd , dd MMMM yyyy "));
            Console.WriteLine(sessionDates[index].ToString("hh:mm tt"));
        }
        #endregion
        #region Part 14 — Read and Validate a Date
        public static void validateADate()
        {
            Console.WriteLine("By following the date format yyyy-MM-dd HH:mm");
            bool flag = false;
            while (!flag)
            {
                Console.Write("Enter a date : ");
                string input = Console.ReadLine()!;
                flag = DateTime.TryParseExact(input, "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime result);
                Console.WriteLine((flag == true) ? "valid date" : "invalid date ,please try again");
            }
        }
        #endregion
        #region Part 15 — Exception Handling: Menu Input
        public static int ValidateMenuInput()
        {
            bool flag = false;
            int input = 0;
            while (!flag)
            {
                Console.Write("Choose an option: ");
                try
                {

                    input = int.Parse(Console.ReadLine()!);

                    flag = true;

                }



                catch (OverflowException)
                {
                    Console.WriteLine("number is too large");
                }
                catch (FormatException)
                {

                    Console.WriteLine("Invalid menu option. Enter a number");
                }
                catch (Exception)
                {
                    Console.WriteLine("invalid input");
                }

            }
            return input;
        }
        #endregion
        #region Part 16 — Exception Handling: Invalid Array Index
        public static void GetSessionByIndex()
        {
            Console.Write("Enter session index : ");
            int.TryParse(Console.ReadLine(), out int index);
            Console.WriteLine((index < sessionNames.Length) ? $"Session: {sessionNames[index]}" : "The selected session index is out of range");
        }
        #endregion
        #region Part 17 — Throw an Exception
        public static void validateDuration()
        {
            Console.Write("Enter duration: : ");
            bool flag = int.TryParse(Console.ReadLine(), out int input);
            if (flag)
            {
                Console.WriteLine((input >= 0) ? "Duration accepted." : "Duration must be greater than zero");
            }
            else
            {
                Console.WriteLine("Duration must be a number");
            }

        }
        #endregion
        #region Part 18 — finally
        public static void mulInverse(double num)
        {
            try
            {
                double num2 = 1 / num;
                Console.WriteLine($"The Multiplication inverse of {num} is {num2}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("The Multiplication inverse of 0 is ∞");
            }
            finally
            {
                Console.WriteLine("Input operation finished");
            }
        }
        #endregion
        #region Part 19 — Build a Schedule Report Using string
        public static string createAScheduleUsingString()
        {
            string result = null!;
            for (int i = 0; i < sessionNames.Length; i++)
            {
                result += sessionNames[i] + "  -  ";
                result += sessionDates[i].ToString("dd/MM/yyyy  ");
                result += sessionDates[i].ToString("hh:mm tt") + "  -  ";
                result += sessionDurations[i] + " minutes\n";

            }
            return result;
        }
        #endregion
        #region Part 20 — Build the Same Report Using StringBuilder
        public static string createAScheduleUsingStringBuilder()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < sessionNames.Length; i++)
            {
                result.Append($"{sessionNames[i]}   -  ");
                result.Append($"{sessionDates[i].ToString("dd/MM/yyyy  ")}");
                result.Append($"{sessionDates[i].ToString("hh:mm tt")}  -  ");
                result.Append($"{sessionDurations[i]} minutes\n");


            }
            return result.ToString();
        }
        #endregion
        #region Part 31 Menu
        public static void Menu()
        {
            int option;
            do
            {

                Console.WriteLine("===================================");
                Console.WriteLine("Academy Schedule Analyzer");
                Console.WriteLine("===================================\n");
                Console.WriteLine("1. Display all sessions\r\n2. Search for a session\r\n3. Sort session names\r\n4. Reverse session names\r\n5. Find session index\r\n6. Check if session exists\r\n7. Show duration statistics\r\n8. Show session date details\r\n9. Show past and upcoming sessions\r\n10. Find next session\r\n11. Compare two session dates\r\n12. Read and validate a custom date\r\n13. Select session by index\r\n14. Validate session duration\r\n15. Generate report using string\r\n16. Generate report using StringBuilder\r\n0. Exit\n\n");
                option = ValidateMenuInput();

                switch (option)
                {
                    case 1:
                        displaySessions();
                        break;

                    case 2:
                        searchSession();
                        break;

                    case 3:
                        sortSessionNames();
                        break;

                    case 4:
                        ReverseSessionNames();
                        break;

                    case 5:
                        FindSessionIndex();
                        break;

                    case 6:
                        CheckIfASessionExists();
                        break;

                    case 7:
                        durationAnalysis();
                        break;

                    case 8:
                        displaySessionDate();
                        //////
                        break;

                    case 9:
                        sessionsStatues();
                        break;

                    case 10:
                        findNextSession();
                        break;

                    case 11:
                        findTimeDiff();
                        break;

                    case 12:
                        validateADate();
                        break;

                    case 13:
                        GetSessionByIndex();
                        break;

                    case 14:
                        validateDuration();
                        break;

                    case 15:
                        Console.WriteLine(createAScheduleUsingString());
                        break;

                    case 16:
                        Console.WriteLine(createAScheduleUsingStringBuilder());
                        break;

                    case 0:

                        Console.WriteLine("\n:)");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose a number from the menu.");
                        break;
                }
            }
            while (option != 0);

        }
        #endregion
        public static void Main(string[] args)
        {
            #region test all functions
            //Logic.displaySessions();
            //Logic.searchSession();
            //Logic.sortSessionNames();
            //Logic.ReverseSessionNames(); 
            //Logic.FindSessionIndex();
            //Logic.CheckIfASessionExists();
            //Logic.FindASessionUsingACondition(n => n.StartsWith("F"));
            //Logic.FindASessionIndexUsingACondition(n => n.StartsWith("F"));
            //Logic.durationAnalysis();
            //Logic.sortDuration();
            #endregion

            #region 4.7 Copy an Array
            //string[] copyArr = new string[sessionNames.Length];
            //Array.Copy(sessionNames, copyArr, sessionNames.Length);


            //Console.WriteLine("Before changing");
            //Console.Write("Session names:");   //session names:[C# Basics ,Arrays ,Functions ,Date and Time ,Exception Handling]
            //displayArray(sessionNames);        //copied session names:[C# Basics ,Arrays ,Functions ,Date and Time ,Exception Handling]
            //Console.Write("Copied session names:");
            //displayArray(copyArr);

            //copyArr[0] = "C# Advanced";

            //Console.WriteLine("After changing");
            //Console.Write("Session names:");   //session names:[C# Basics ,Arrays ,Functions ,Date and Time ,Exception Handling]
            //displayArray(sessionNames);        //copied session names:[C# Advanced ,Arrays ,Functions ,Date and Time ,Exception Handling]
            //Console.Write("Copied session names:");
            //displayArray(copyArr);// the copied array does not change the original array
            #endregion

            #region Test part 7
            //int x = 5;
            //Console.WriteLine("Value Before calling function : " + x); //5
            //Logic.squareValue(ref x);
            //Console.WriteLine("Value After calling function : " + x);  //25

            //Logic.sessionDetailsReturn(out int index, out int sessionDuration);
            //Console.WriteLine($"index : {index}");
            //Console.WriteLine($"sessionDuration : {sessionDuration}");

            //int y = 16;
            //Console.WriteLine("Value Before calling function : " + y); //16
            //Logic.squareRoot(y);
            //Console.WriteLine("Value After calling function : " + y);  //1
            #endregion

            #region Test part 8
            //Console.WriteLine(Logic.CalculateTotalDuration(10, 20, 30));
            #endregion

            //var summary = BenchmarkRunner.Run<StringBenchmark>();
            Menu();
        }
    }
    
}
