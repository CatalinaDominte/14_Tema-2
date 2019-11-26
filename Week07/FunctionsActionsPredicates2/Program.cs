namespace FunctionsActionsPredicates2
{
    using System;

    internal class Student
    {
    }

    internal class Program
    {
        public delegate void Printer(string s);

        private static void Main(string[] args)
        {
            //Printer printer;

            //printer = PrintWithRed;

            //printer("ceva 2");

            //CallPrinter(printer, "ceva 1");

            // mod 1
            //Action<string> action = PrintWithRed;
            //action("ceva 2");

            //mod 2
            Action<string, int, Student> action2 = Method;
            var action3 = new Action<string, int, Student>(Method);

            // mod 3
            //Action<string> printToUpper = delegate(string value)
            //{
            //    Console.WriteLine(value.ToUpper());
            //};

            //printToUpper("and");

            // mod 4
            Action<string> printToUpper2 = value => { Console.WriteLine(value.ToUpper()); };
            printToUpper2("and");
            ActionRunner(printToUpper2, "something");

            ActionRunner(s =>
            {
                Console.WriteLine(s.ToLower());
            }, "ABC");

            ActionRunner(PrintWithGreen, "red");
        }

        public static void ActionRunner(Action<string> action, string value)
        {
            action(value);
        }

        public static void Method(string i, int a, Student s)
        {
        }

        public static void CallPrinter(Printer p, string value)
        {
            p(value);
        }

        public static void SomeAction1()
        {
            Console.WriteLine("print from SomeAction1");
        }

        public static void PrintWithRed(string value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(value);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintWithGreen(string value)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(value);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
