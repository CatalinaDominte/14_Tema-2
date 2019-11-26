namespace FunctionsActionsPredicates
{
    using System;
    using System.Runtime.CompilerServices;

    internal class Program
    {
        public delegate void Printer(string s);

        private static void Main(string[] args)
        {
            //PrintWithRed("Wantsome");

            //PrintWithGreen("Wantsome");

            Printer printer;

            //if (DateTime.Now.Second % 2 == 0)
            //{
            //    printer = PrintWithRed;
            //    printer += PrintWithGreen;
            //}
            //else
            //{
            //    printer = PrintWithGreen;
            //    printer += PrintWithRed;
            //}

            printer = PrintWithGreen;
            printer += PrintWithRed;

            DelegateRunner(printer, "Hello");

            printer.Invoke("Hello 2");
            printer("Hello 2");

            printer("Hello again");
        }

        public static void DelegateRunner(Printer p, string value)
        {
            p(value);
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
