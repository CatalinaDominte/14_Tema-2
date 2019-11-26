namespace ExtensionMethods
{
    using System;
    using System.Diagnostics.Eventing.Reader;

    // TODO
    // - decimal 1299.321312
    // - decimal 123512321.321321
    // x.FormatWith2Dec() 1299.32, 123512321.32

    public static class DecimalExtensions
    {
        public static string FormatWith2Dec(this decimal d)
        {
            return d.ToString("##.##");
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            decimal d = 1299.321312m;
            string newD = d.FormatWith2Dec();
            string newD2 = DecimalExtensions.FormatWith2Dec(d);
            Console.WriteLine(newD);

            //int i = 10;

            ////bool result = i.IsGreaterThan(100);

            //bool result = Helpers.CompareNumbers(i, 100);
            //Console.WriteLine(result);

            ////bool result2 = ExtensionMethods.IsGreaterThan(i, 100);
            int i = 200;
            bool result3 = i.IsGreaterThan(100, 200);
        }
    }

    public static class ExtensionMethods
    {
        public static bool IsGreaterThan(this int a, int b)
        {
            if (a > b)
            {
                return true;
            }

            return false;
        }

        public static bool IsGreaterThan(this int a, int b, int c)
        {
            if (a > b && a > c)
            {
                return true;
            }

            return false;
        }
    }

    public class Helpers
    {
        public static bool CompareNumbers(int a, int b)
        {
            if (a > b)
            {
                return true;
            }

            return false;
        }
    }
}
