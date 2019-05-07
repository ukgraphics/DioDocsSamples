using System;
using DDClassLibrary1;

namespace DDConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            DDExcel.Create(".NET Core Console App");

            DDPdf.Create(".NET Core Console App");

        }
    }
}
