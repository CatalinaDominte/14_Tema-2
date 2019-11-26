namespace FunctionsActionsPredicates3
{
    using System;

    public delegate int SomeOperation(int i, int j);

    public delegate bool Check(string s);

    class Program
    {
        static void Main(string[] args)
        {
            // Functions();

            // old. using delegates.
            Check check = IsPalindrome;

            // predicates
            Predicate<string> check2 = IsPalindrome;

            Predicate<string> check3 = delegate(string s) { return true; };

            Predicate<string> check4 = s => { return false; };

            Console.WriteLine(check("ana"));
            Console.WriteLine(check2("ana"));
        }

        public static bool IsPalindrome(string s)
        {
            for (int i = 0; i < s.Length/2; i++)
            {
                if (s[i] != s[s.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        static int Sum(int x, int y)
        {
            return x + y;
        }

        private static void Functions()
        {
            SomeOperation add = Sum;

            int result = add(10, 10);

            Console.WriteLine(result);

            Func<int, int, int> add2 = Sum;

            var result2 = add2(1, 2);

            Func<int, int, int> add3 = delegate(int a, int b) { return a + b; };

            Func<int, int, int> add4 = (int a, int b) => { return a + b; };

            Func<int, int, int> add5 = (a, b) => { return a + b; };

            Func<int, int, double> division = (a, b) => { return (double) a / b; };
        }
    }
}
