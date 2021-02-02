using System;

namespace TheSecretOfAhmed
{
    class Hero
    {
        public int Coins { get; set; }
        public int Health { get; set; }
        public string Name { get; set; }
        public Hero()
        {
            Coins = 100;
            Health = 100;
        }
        public int PrintChoice(string s)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 8);
            Console.WriteLine("\n1. Бежать");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("2. Отдать деньги\n3. Сражаться");
            int res = 1;
            ConsoleKey button = Console.ReadKey().Key;
            while (button != ConsoleKey.Enter)
            {
                switch (button)
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
                button = Console.ReadKey().Key;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            return res;
        }
        public void PrintStatic()
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
