﻿using System;
using System.Collections.Generic;

namespace Battleship
{
    public class Map
    {
        // the map indicating the place where the player places his bombs onto the map of his opponent.
        public char[,] BombMap { get; private set; }

        // the map indicating the place where the player places his ships.
        public char[,] ShipMap { get; private set; }

        public string PlayerName { get; set; }
        public int Score { get; private set; }

        // whether this player has win.
        public bool HasWin { get; private set; }

        private Game game;

        public Map(string n, Game g)
        {
            game = g;
            PlayerName = n;
            Score = 0;
            HasWin = false;

            Console.WriteLine("--------- The sea of " + PlayerName + " ------------");
            Console.WriteLine();

            ShipMap = new char[11, 11];
            BombMap = new char[11, 11];

            /* Initialization for the sea of player as well as the bomb ShipMap of enemy. */
            /* 47 indicating the place of '0' in ASCII, as well as 64, the place of 'A'. */
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (i == 0 && j == 0)
                        BombMap[i, j] = ShipMap[i, j] = ' ';
                    else if (i == 0)
                        BombMap[i, j] = ShipMap[i, j] = (char)(j + 47);
                    else if (j == 0)
                        BombMap[i, j] = ShipMap[i, j] = (char)(i + 64);
                    else
                        BombMap[i, j] = ShipMap[i, j] = '~';
                }
            }

            Display();

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------");


            List<Ship> ships = new List<Ship>();

            Ship ship1 = new Ship("AIRCRAFT CARRIER", 5);
            Ship ship2 = new Ship("BATTLESHIP", 4);
            Ship ship3 = new Ship("CRUISER", 3);
            Ship ship4 = new Ship("SUBMARINE", 3);
            Ship ship5 = new Ship("DESTROYER", 2);
            ships.Add(ship1);
            ships.Add(ship2);
            ships.Add(ship3);
            ships.Add(ship4);
            ships.Add(ship5);

            foreach (Ship s in ships)
            {
                bool isValidated;
                do
                {
                    isValidated = PlaceShip(s);
                }
                while (!isValidated);
            }
        }


        public bool PlaceShip(Ship ship)
        {
            Console.WriteLine("Please place " + ship.Name + " with a length of " + ship.Len + " holes onto your sea.");
            Console.WriteLine();
            Console.WriteLine("Give me the coordinates that you wish to put this ship.");

            char x;
            char y;

            // horizontal or vertical
            char dir;
            // left or right, up or down
            char dir2;

            /* Get input of x and y. */
            do
            {
                Console.Write("Give me the horizontal value (from 0 to 9) : ");
                x = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (x < '0' || x > '9')
                {
                    Console.WriteLine();
                    Console.WriteLine("!!!invalid input!!!");
                }
            }
            while (x < '0' || x > '9');
            do
            {
                Console.Write("Give me the vertical value (from A to J) in UPPERCASE : ");
                y = Console.ReadKey().KeyChar;
                y = ToUpper(y);
                Console.WriteLine();
                if (y < 'A' || y > 'J')
                {
                    Console.WriteLine();
                    Console.WriteLine("!!!invalid input!!!");
                }
            }
            while (y < 'A' || y > 'J');

            /* Get input of dir */
            do
            {
                Console.Write("In which direction ? (H for 'Horizontal', V for 'Vertical'): ");
                dir = Console.ReadKey().KeyChar;
                dir = ToUpper(dir);
                Console.WriteLine();
                if (dir != 'H' && dir != 'V')
                {
                    Console.WriteLine();
                    Console.WriteLine("!!!invalid input!!!");
                }
            }
            while (dir != 'H' && dir != 'V');


            /* Get input of dir2 */
            if (dir == 'H')
            {
                do
                {
                    Console.Write("Towards Left or towards Right ? (L for 'Left', R for 'Right'): ");
                    dir2 = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    dir2 = ToUpper(dir2);
                    if (dir2 != 'L' && dir2 != 'R')
                    {
                        Console.WriteLine();
                        Console.WriteLine("!!!invalid input!!!");
                    }
                }
                while (dir2 != 'L' && dir2 != 'R');
            }
            else
            {
                do
                {
                    Console.Write("Upwards or Downwards ? (U for 'Upwards', D for 'Downwards'): ");
                    dir2 = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    dir2 = ToUpper(dir2);
                    if (dir2 != 'U' && dir2 != 'D')
                    {
                        Console.WriteLine();
                        Console.WriteLine("!!!invalid input!!!");
                    }
                }
                while (dir2 != 'U' && dir2 != 'D');
            }

            Console.WriteLine();


            if (CheckPlacement((int)(y - 64), (int)(x - 47), dir, dir2, ship.Len))
            {
                ValidatePlacement((int)(y - 64), (int)(x - 47), dir, dir2, ship.Len, ship.Name[0]);
                Console.Clear();
                Display();
                return (true);
            }
            else
            {
                Console.WriteLine("!!! The place you choose in not available, please redo it !!!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                Display();
                return (false);
            }
        }

        /* Check placement of ship. */
        public bool CheckPlacement(int x, int y, char dir1, char dir2, int len)
        {

            for (int i = 0; i < len; i++)
            {
                if (dir1 == 'H' && dir2 == 'R' && (y + len - 1) < 11)
                {
                    if (ShipMap[x, y + i] == '~')
                        continue;
                    return (false);

                }
                else if (dir1 == 'H' && dir2 == 'L' && (y - len + 1) >= 1)
                {
                    if (ShipMap[x, y - i] == '~')
                        continue;
                    return (false);
                }

                else if (dir1 == 'V' && dir2 == 'D' && (x + len - 1) < 11)
                {
                    if (ShipMap[x + i, y] == '~')
                        continue;
                    return (false);

                }
                else if (dir1 == 'V' && dir2 == 'U' && (x - len + 1) >= 1)
                {
                    if (ShipMap[x - i, y] == '~')
                        continue;
                    return (false);
                }
                else
                    return (false);
            }
            return (true);
        }

        /* Place the ship with the first char of the ship's name. */
        public void ValidatePlacement(int x, int y, char dir1, char dir2, int len, char name)
        {
            for (int i = 0; i < len; i++)
            {
                if (dir1 == 'H' && dir2 == 'R')
                    ShipMap[x, y + i] = name;
                else if (dir1 == 'H' && dir2 == 'L')
                    ShipMap[x, y - i] = name;
                else if (dir1 == 'V' && dir2 == 'D')
                    ShipMap[x + i, y] = name;
                else if (dir1 == 'V' && dir2 == 'U')
                    ShipMap[x - i, y] = name;
            }
        }

        public void PlaceBomb()
        {
            char x;
            char y;

            Console.WriteLine(PlayerName + ", please place a bomb onto the sea of enemy.");
            Console.WriteLine("Give me the coordinates that you wish to put this bomb.");

            /* Get input of x and y. */
            do
            {
                Console.Write("Give me the horizontal value (from 0 to 9) : ");
                x = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (x < '0' || x > '9')
                {
                    Console.WriteLine();
                    Console.WriteLine("!!!invalid input!!!");
                }
            }
            while (x < '0' || x > '9');
            do
            {
                Console.Write("Give me the vertical value (from A to J) in UPPERCASE : ");
                y = Console.ReadKey().KeyChar;
                y = ToUpper(y);
                Console.WriteLine();
                if (y < 'A' || y > 'J')
                {
                    Console.WriteLine();
                    Console.WriteLine("!!!invalid input!!!");
                }
            }
            while (y < 'A' || y > 'J');

            
            // 64 and 47 here is linked to the ASCII code
            int a = y - 64;
            int b = x - 47;

            // place bomb
            if (game.MapEnemy.ShipMap[a, b] != '~' && game.MapEnemy.ShipMap[a, b] != '*' && game.MapEnemy.ShipMap[a, b] != '@')
            {
                BombMap[a, b] = '@';
                Score++;

                // the total score here is calculated based on the length of all the ships
                if (Score >= 17)
                    HasWin = true;
                game.MapEnemy.ShipMap[a, b] = '@';

                Random rand = new Random();
                int i = rand.Next(3);
                if (i == 0)
                    Console.WriteLine("!!!STRIKE !!!");
                else if (i == 1)
                    Console.WriteLine("You hit it !!!");
                else if (i == 2)
                    Console.WriteLine("One shot !!!");

                Console.WriteLine("Now it is still your turn, press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            else if (game.MapEnemy.ShipMap[a, b] == '*' || game.MapEnemy.ShipMap[a, b] == '@')
            {
                Console.WriteLine("You have already placed a bomb here, choose another place.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                BombMap[a, b] = '*';
                game.MapEnemy.ShipMap[a, b] = '*';
                game.ExchangeMap();
                Random rand = new Random();
                int i = rand.Next(3);
                if (i == 0)
                    Console.WriteLine("NO HIT...");
                else if (i == 1)
                    Console.WriteLine("What a pity...");
                else if (i == 2)
                    Console.WriteLine("You missed it...");


                Console.WriteLine("Now it is your opponent's turn, press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        /* Display ShipMap */
        public void Display()
        {
            Console.WriteLine();

            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    Console.Write(ShipMap[i, j]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /* Display ShipMap as well as BombMap of his opponent horizontally. */
        public void DisplayTwoMap()
        {
            Console.WriteLine();

            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    Console.Write(ShipMap[i, j]);
                    Console.Write(' ');
                }
                Console.Write("             ");
                for (int k = 0; k < 11; k++)
                {
                    Console.Write(BombMap[i, k]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public char ToUpper(char c)
        {
            int offset = 'a' - 'A';
            if (c >= 'a' && c<= 'z')
            {
                c = ((char)(c - offset));
            }
            return (c);
            
        }
    }
}
