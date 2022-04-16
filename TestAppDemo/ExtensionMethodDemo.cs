using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethods;
namespace TestAppDemo
{
    class ExtensionMethodDemo
    {
        static void Main(string[] args)
        {
            string name = "Ram ";
            Console.WriteLine(name.ToStringUpperCase());
            Console.ReadLine();

            try
            {
                int number = Convert.ToInt32("sarvesh");
            }
            catch (Exception ex)
            {

                int linenumber = ex.Linenumber();
                Console.WriteLine(linenumber);
            }
        }
    }


}

