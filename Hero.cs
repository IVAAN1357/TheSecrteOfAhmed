using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    class Hero
    {
        public int Coins = 100;
        public int Health = 100;
        public string Name;
        public int GetAction(string s)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 8);
            Console.WriteLine("\n1. Бежать");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("2. Отдать деньги\n3. Сражаться");
            int res = 1;
            ConsoleKey butt = Console.ReadKey().Key;
            while (butt != ConsoleKey.Enter)
            {
                switch (butt)
                {
                    case ConsoleKey.UpArrow:
                        {

                            if (res == 1)
                            {
                                res = 3;
                                Console.SetCursorPosition(0, 8);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("\n1. Бежать\n2. Отдать деньги");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("3. Сражаться");
                            }
                            else if (res == 2)
                            {
                                res = 1;
                                Console.SetCursorPosition(0, 8);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\n1. Бежать");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("2. Отдать деньги\n3. Сражаться");
                            }
                            else
                            {
                                res = 2;
                                Console.SetCursorPosition(0, 8);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("\n1. Бежать");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("2. Отдать деньги");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("3. Сражаться");
                            }
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (res == 1)
                            {
                                res = 2;
                                Console.SetCursorPosition(0, 8);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("\n1. Бежать");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("2. Отдать деньги");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("3. Сражаться");
                            }
                            else if (res == 2)
                            {
                                res = 3;
                                Console.SetCursorPosition(0, 8);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("\n1. Бежать\n2. Отдать деньги");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("3. Сражаться");
                            }
                            else
                            {
                                res = 1;
                                Console.SetCursorPosition(0, 8);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\n1. Бежать");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("2. Отдать деньги\n3. Сражаться");
                            }
                            break;
                        }
                }
                butt = Console.ReadKey().Key;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            return res;
        }
        public void GetStatic()
        {
            switch (Coins)
            {
                case 100:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case 50:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 0:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
            }
            Console.WriteLine($"\nТвои монеты: {Coins}");
            if (Health >= 50)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine($"Твои жизни: {Health}\n");
            Console.ForegroundColor = ConsoleColor.Green;
        }


    }
}
