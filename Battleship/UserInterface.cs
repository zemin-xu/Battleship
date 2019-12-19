using System;
namespace Battleship
{
    public class UserInterface
    {
        private Map mapInPlaying;
        private Map mapEnemy;

        public UserInterface(Map _mapInPlaying, Map _mapEnemy)
        {
            mapInPlaying = _mapInPlaying;
            mapEnemy = _mapEnemy;
        }

        public void Display()
        {
            Console.WriteLine("----------- YOUR SEA ---------- THE BOMB MAP OF ENEMY'S SEA ----------");
            Console.WriteLine();
            mapInPlaying.DisplayTwoMap();
            Console.WriteLine();

            Console.WriteLine("---------- Indication to " + mapInPlaying.PlayerName + " -------------");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(mapInPlaying.PlayerName + " 's score : " + mapInPlaying.Score);
            Console.WriteLine(mapEnemy.PlayerName + " 's score : " + mapEnemy.Score);
        }
    }
}
