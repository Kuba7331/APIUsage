using System;
using System.Collections.Generic;
using System.Text;
using RiotSharp;
namespace TEST5 
{
    public class MainController {
        static public void Main()
        {
            while (true)
            {
                RiotAPI.ShowUserData();
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    Console.WriteLine(" Nastepuje wyjscie z aplikacji...");
                    Environment.Exit(0);
                }
                Console.Clear();
            }
        }
    }
}
