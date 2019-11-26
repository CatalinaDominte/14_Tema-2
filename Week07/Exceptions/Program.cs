using System;

namespace Exceptions
{
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 1, 2, 3, 5, -1, -1, -2, 4, 24, 4};

            foreach (var elem in list)
            {
                try
                {
                    if (elem < 0)
                    {
                        throw new InvalidOperationException($"Elem is negative: {elem}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            try
            {
                foreach (var elem in list)
                {
                    if (elem < 0)
                    {
                        throw new InvalidOperationException($"Elem is negative: {elem}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            //try
            //{
            //    EnterNumber();
            //}
            //catch (CustomProgramException e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.WriteLine(e.InnerException.Message);
            //}

            //ClassEx();
        }

        private static void PrintElem(int elem)
        {
            try
            {
                if (elem < 0)
                {
                    throw new InvalidOperationException($"Elem is negative: {elem}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void ClassEx()
        {
            //string input1
            //string input2

            //parse la int

            // if input1 = input2 = 0 => throw custom exception

            //division

            //catch -format
            //catch -division
            //catch -all exceptions

            Console.WriteLine("NR1");
            var s1 = Console.ReadLine();

            Console.WriteLine("NR2");
            var s2 = Console.ReadLine();

            try
            {
                int i1 = int.Parse(s1);
                int i2 = int.Parse(s2);

                if(i1 == 0 && i2 == 0)
                {
                    throw new BothArgsAreZeroException();
                }

                int result = i1 / i2;
                Console.WriteLine(result);
            }
            catch (BothArgsAreZeroException e)
            {
                Console.WriteLine($"BothArgsAreZeroException {e.StackTrace}");

                //throw;
            }
            catch (FormatException e)
            {
                Console.WriteLine($"ArgumentException {e.StackTrace}");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine($"DivideByZeroException {e.StackTrace}");
            }

        }

        public static void EnterNumber()
        {
            try
            {
                Console.WriteLine("Enter number 1");
                string input1 = Console.ReadLine();
                int i1 = int.Parse(input1);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("FormatException");

                throw new CustomProgramException("my exception", ex);
            }
            finally
            {
                Console.WriteLine("Mesaj de final");
            }
        }

        public static void ExceptionHandling()
        {

            Console.WriteLine("Division");

            Console.WriteLine("Enter number 1");
            string input1 = Console.ReadLine();

            Console.WriteLine("Enter number 2");
            string input2 = Console.ReadLine();

            try
            {
                int i1 = int.Parse(input1);
                int i2 = int.Parse(input2);

                double result = i1 / i2;

                Console.WriteLine(result);
            }
            catch (FormatException e)
            {
                Console.WriteLine("FormatException");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("DivideByZeroException");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            catch (ArithmeticException e)
            {
                Console.WriteLine("ArithmeticException");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Console.WriteLine("Mesaj de final");
            }

            Console.ReadKey();
        }
    }
}
