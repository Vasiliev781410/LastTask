using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ScanFolder
{
    class Program
    {
        static void Main(string[] args)
        {
            bool stop = false;
            Console.WriteLine("Enter name of folder for scan like this D:\\\\Health (for example)");
            do
            {
                ScanFolder1.FinderService invoker = new ScanFolder1.FinderService();
                string baseDirectory = Console.ReadLine();
                if (String.IsNullOrEmpty(baseDirectory) == false)
                {
                   invoker.FindFolder(baseDirectory);   
                }
                else
                {
                    Console.WriteLine("This is incorrect folder's name");
                }
            } while (stop == false);             
            Console.ReadLine();
            }
        }
}
