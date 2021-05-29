using System;
using System.Collections.Generic;
using System.Text;

namespace Product.ConsoleApp
{
    partial class Program
    {
        static void Center(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(new string(' ', Console.WindowWidth / 2 - text.Length / 2));
            Console.Write(text);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Table(object text)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(new string(' ', Console.WindowWidth / 2 - (Convert.ToString(text).Length / 2)));
            Console.Write(text);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
        static void Error(string text)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(text);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Success(string text)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(text);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Choose(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(new string(' ', Console.WindowWidth / 6));
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
