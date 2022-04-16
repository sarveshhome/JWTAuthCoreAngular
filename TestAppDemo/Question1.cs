using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppDemo
{
    class Question1
    {
        static void Main(string[] args)
        {
            var newlist = new List<int> { 10, 20, 2, -19, 33 };
            var ResultMaxValue=   newlist.Max(a => a);
            var ResultMinValue = newlist.Min(a => a);
            var ResultSumValue = newlist.Sum(a => a);

            Console.WriteLine("Max value: " + ResultMaxValue);
            Console.WriteLine("Man value: " + ResultMinValue);
            Console.WriteLine("Sum value: " + ResultSumValue);

            var genericResultAdd =  Adds(10, 20);
            Console.WriteLine( "Generic result "+genericResultAdd);
            
        }

        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
        static T Adds<T>( T value1,T value2) 
        {
            T result;
            dynamic add1 = value1;
            dynamic add2 = value2;
            result = add1 - add2;
            return result;
        }
    }
}
