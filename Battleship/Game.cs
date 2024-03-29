﻿using System;
namespace Battleship
{
    public class Game
    {
        // current player
        public Map MapActive { get; private set; }

        // the opponent of current player
        public Map MapEnemy { get; private set; }

        public Game()
        {
            /* Initialization of Game */
            Console.WriteLine("Please type in the name of Player 1");
            Console.WriteLine("-----------------------------------");
            string player1 = Console.ReadLine();
            Console.Clear();
            MapActive = new Map(player1, this);
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("The ships of " + MapActive.PlayerName + " are set!");
            Console.WriteLine("Now it is the turn of Player 2");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Please type in the name of Player 2");
            Console.WriteLine("-----------------------------------");
            string player2 = Console.ReadLine();
            Console.Clear();
            MapEnemy = new Map(player2, this);
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("The ships of " + MapEnemy.PlayerName + " are set!");
            Console.WriteLine(" !!! Now the war will begin !!! ");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();

            /* In Game */
            while (!MapActive.HasWin && !MapEnemy.HasWin)
            {
                UserInterface ui = new UserInterface(MapActive, MapEnemy);
                ui.Display();
                MapActive.PlaceBomb();
            }

            /* When a player wins. */
            MapActive.DisplayTwoMap();
            FinishGame();
        }

        public void ExchangeMap()
        {
            Map tmp = MapActive;
            MapActive = MapEnemy;
            MapEnemy = tmp;
        }

        public void FinishGame()
        {
            Console.WriteLine(" !!! Congratulations " + MapActive.PlayerName + " . You have conquered your enemy " + MapEnemy.PlayerName + " .");
            Console.WriteLine(MapActive.PlayerName + " 's score : " + MapActive.Score);
            Console.WriteLine(MapEnemy.PlayerName + " 's score : " + MapEnemy.Score);

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        } 
    }
}
