using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structs
{
    public interface IStudent
    {
        void Sleep();
    }

    public struct Money
    {
        public decimal Amount { get; set; }

        public string Currency { get; set; }
    }

    public class Student : IStudent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<int> SomeInts { get; set; }

        public void Sleep()
        {
            throw new NotImplementedException();
        }
    }

    //public struct SuperStudent : Student
    //{
    //    public string Scholarship { get; set; }

    //    public void UpdateName(string name)
    //    {
    //        this.Name = name;
    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            //DateTime d1 = new DateTime(2012, 12, 12);
            //DateTime d2 = new DateTime(2012, 12, 12);

            //Student s1 = new Student();
            //Student s2 = new Student();

            Money m1 = new Money { Amount = 200, Currency = "EUR" };
            Money m2 = new Money { Amount = 200, Currency = "EUR" };
        }
    }
}
