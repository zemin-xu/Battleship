using System;
namespace Battleship
{
    public class Game
    {
        public Game()
        {
            Console.WriteLine("Please type in the name of Player 1");
            Console.WriteLine("-----------------------------------");
            string player1 = Console.ReadLine();
            Console.Clear();
            Map map1 = new Map(player1);
            
        }
    }
}
