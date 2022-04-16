using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppDemo
{ 
  
    public sealed class SingletonDemo
    {
            private static int counter = 0;
            private static SingletonDemo instance = null;
            public static SingletonDemo GetInstance
            {
                get
                {
                    if (instance == null)
                        instance = new SingletonDemo();
                    return instance;
                }
            }

            private SingletonDemo()
            {
                counter++;
                Console.WriteLine("Counter Value " + counter.ToString());
            }

            public void PrintDetails(string message)
            {
                Console.WriteLine(message);
            }
    }

    class Singletoncls
    {
        static void Main(string[] args)
        {
            SingletonDemo fromTeachaer = SingletonDemo.GetInstance;
            fromTeachaer.PrintDetails("From Teacher");
            SingletonDemo fromStudent = SingletonDemo.GetInstance;
            fromStudent.PrintDetails("From Student");
            Console.ReadLine();
        }
    }
}
