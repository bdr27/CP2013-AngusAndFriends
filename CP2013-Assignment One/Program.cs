using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2013_Assignment_One
{
    class Program
    {
        const string MENU = "Where do you wish to do\n\t1. User UI\n\t2. Admin UI\n\t(Q)uit";
        static void Main(string[] args)
        {
            Console.WriteLine(MENU);
            var key = Console.ReadLine().ToLower();
            while (key != "q")
            {
                Console.Clear();
                switch (key)
                {
                    case "1":
                        UserUI();
                        break;
                    case "2":
                        AdminUI();
                        break;
                    default:
                        Console.WriteLine("unknown error");
                        break;
                }
                Console.WriteLine(MENU);
                key = Console.ReadLine().ToLower();
            }
        }

        static void AdminUI()
        {
            //Add new dentist
            Console.WriteLine("Admin UI");
        }

        static void UserUI()
        {
            Console.WriteLine("User UI");
        }
    }
}
