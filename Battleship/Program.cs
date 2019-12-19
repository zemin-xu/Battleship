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

                // menu
                switch (command)
                {
                    case 'n':
                    case 'N':
                        Console.Clear();
                        Game game = new Game();
                        break;

                    case 'd':
                    case 'D':
                        {
                            Console.Clear();

                            Console.WriteLine("The game is played on four grids, two for each player." +
                " The grids are typically square – usually 10×10 – and the individual squares in the grid are identified by letter and number." +
                " On one grid the player arranges ships and records the shots by the opponent. On the other grid the player records their own shots.");

                            Console.WriteLine();
                            Console.WriteLine("Press any key to continue...");
                            Console.Read();
                            Console.Clear();

                            Console.WriteLine("Before play begins, each player secretly arranges their ships on their primary grid." +
                                " Each ship occupies a number of consecutive squares on the grid, arranged either horizontally or vertically." +
                                " The number of squares for each ship is determined by the type of the ship. " +
                                "The ships cannot overlap (i.e., only one ship can occupy any given square in the grid). " +
                                "The types and numbers of ships allowed are the same for each player. These may vary depending on the rules.");

                            Console.WriteLine();
                            Console.WriteLine("Press any key to continue...");
                            Console.Read();
                            Console.Clear();

                            Console.WriteLine("After the ships have been positioned, the game proceeds in a series of rounds." +
                                " In each round, each player takes a turn to announce a target square in the opponent's grid which is to be shot at." +
                                " The opponent announces whether or not the square is occupied by a ship. " +
                                "If it is a 'hit', the player who is hit marks this with '@'. This player can also continue to shot. " +
                                "If not, it is marked as '*'. " +
                                "The game ends up with any player whose ships are all destroyed.");

                            Console.WriteLine();
                            Console.WriteLine("Press any key to return to the menu...");
                            Console.Read();
                            Console.Clear();
                        }
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
