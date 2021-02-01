using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSAGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool willContinue = true;
            int menu = -1;
            while (willContinue)
            {
                Console.WriteLine("Enter to select function:");
                Console.WriteLine("1. Gernate Private/Public RSA256 Key Pair");
                Console.WriteLine("9. Exit");
                
                int.TryParse(Console.ReadLine(), out menu);

                switch (menu)  
                {
                    case 1:
                        //statement 
                        break;

                    //case 2:
                    //    //statement 
                    //    break;

                    //case 3:
                    //    //statement 
                    //    break;

                    case 4:
                    default:
                        willContinue = false;
                        break;
                }
            }
        }
    }
}
