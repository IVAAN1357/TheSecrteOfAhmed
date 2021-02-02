using System;

namespace TheSecretOfAhmed
{
    class Program
    {   
        static void Main(string[] args)
        {
            Console.Title = "Тайна Ахмеда";
            Hero player = new Hero();
            Adventure Journey = new Adventure(player);
            Journey.Begin();
            Console.Clear();
         }
    }
}
