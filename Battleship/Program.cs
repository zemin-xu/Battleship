using System;

namespace Battleship
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("---- Battleship Game Menu ----");
                Console.WriteLine("------------------------------");
                Console.WriteLine();

                Console.WriteLine("Press N to start a new game");
                Console.WriteLine("Press D to the description of gameplay");
                Console.WriteLine("Press Q to quit the game");
                Console.WriteLine();

                char command = (char)Console.Read();

                switch (command)
                {
                    case 'n':
                    case 'N':
                        Console.Clear();
                        Game game = new Game();
                        break;

                    case 'd':
                    case 'D':
                        Console.Clear();
                        // description
                        break;

                    case 'q':
                    case 'Q':
                        Console.Clear();
                        Environment.Exit(1);
                        break;

                    default:
                        Console.Clear();
                        break;
                }
            }
            while (true);   
        }
    }
}
