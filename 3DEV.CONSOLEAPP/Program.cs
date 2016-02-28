using _3DEV.DATA;
using System;

namespace _3DEV.CONSOLEAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing Database ...");

            DataContext context = new DataContext();
            context.Database.Initialize(true);

            Console.WriteLine("Done ...");
            Console.ReadLine();
        }
    }
}
