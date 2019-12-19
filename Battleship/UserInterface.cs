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
            Console.WriteLine("------------- YOUR SEA ------------------- THE BOMB MAP OF ENEMY'S SEA ----------");
            Console.WriteLine();
            mapInPlaying.Display();
            Console.WriteLine();
            


            
            Console.WriteLine();
            mapInPlaying.DisplayBombMap();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("---------- Indication -----------");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Your score : " + mapInPlaying.Score);
            Console.WriteLine("Enemy's score : " + mapEnemy.Score);
        }
    }
}
