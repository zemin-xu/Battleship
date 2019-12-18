using System;
using System.Collections.Generic;

namespace Battleship
{
    public class Map
    {
        private char[,] map;

        public string PlayerName { get; set; }

        public Map(string n)
        {

            PlayerName = n;

            Console.WriteLine("--------- The sea of " + PlayerName + " ------------");

            map = new char[11, 11];
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (i == 0 && j == 0)
                        map[i, j] = ' ';
                    else if (i == 0)
                        map[i, j] = (char)(j + 47);
                    else if (j == 0)
                        map[i, j] = (char)(i + 64);
                    else
                        map[i, j] = '~';
                }
            }
            Display();


            List<Ship> ships = new List<Ship>();

            Ship ship1 = new Ship("Aircraft Carrier", 5);
            Ship ship2 = new Ship("Battleship", 4);
            Ship ship3 = new Ship("Cruiser", 3);
            Ship ship4 = new Ship("Submarine", 3);
            Ship ship5 = new Ship("Destroyer", 2);
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
            Console.WriteLine("Give me the coordinates that you wish to put this ship.");
            

            char x;
            char y;
            char dir;
            char dir2;

            do
            {
                Console.Write("Give me the horizontal value (from 0 to 9) :");
                x = (char)Console.Read();
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
                Console.Write("Give me the vertical value (from A to J) in UPPERCASE :");
                y = (char)Console.Read();
                Console.WriteLine();
                if (y < 'A' || y > 'J')
                {
                    Console.WriteLine();
                    Console.WriteLine("!!!invalid input!!!");
                }
            }
            while (y < 'A' || y > 'J');

            do
            {
                Console.Write("In which direction ? (H for 'Horizontal', V for 'Vertical'): ");
                dir = (char)Console.Read();
                Console.WriteLine();
                if (dir != 'H' && dir != 'V')
                {
                    Console.WriteLine();
                    Console.WriteLine("!!!invalid input!!!");
                }
            }
            while (dir != 'H' && dir != 'V');


            if (dir == 'H')
            {
                do
                {
                    Console.Write("Towards Left or towards Right ? (L for 'Left', R for 'Right'): ");
                    dir2 = (char)Console.Read();
                    Console.WriteLine();
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
                    dir2 = (char)Console.Read();
                    Console.WriteLine();
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
                Console.Clear();
                Display();
                return (false);
                }
                 

            

        }

        public bool CheckPlacement(int x, int y, char dir1, char dir2, int len)
        {
          
                for (int i = 0; i < len; i++)
                {
                if (dir1 == 'H' && dir2 == 'R' && (y + len - 1) < 11)
                {
                    if (map[x, y + i] == '~')
                        continue;
                    return (false);

                }
                else if (dir1 == 'H' && dir2 == 'L' && (y - len + 1) >= 1)
                {
                    if (map[x, y - i] == '~')
                        continue;
                    return (false);
                }

                else if (dir1 == 'V' && dir2 == 'D' && (x + len - 1) < 11)
                {
                    if (map[x + i, y] == '~')
                        continue;
                    return (false);

                }
                else if (dir1 == 'V' && dir2 == 'U' && (x - len + 1) >= 1)
                {
                    if (map[x - i, y] == '~')
                        continue;
                    return (false);
                }
                else
                    return (false);
                }
            return (true);
        }

        public void ValidatePlacement(int x, int y, char dir1, char dir2, int len, char name)
        {
            for (int i = 0; i < len; i++)
            {
                if (dir1 == 'H' && dir2 == 'R')
                    map[x, y + i] = name;
                else if (dir1 == 'H' && dir2 == 'L')
                    map[x, y - i] = name;
                else if (dir1 == 'V' && dir2 == 'D')
                    map[x + i, y] = name;
                else if (dir1 == 'V' && dir2 == 'U')
                    map[x - i, y] = name;
            }
        }

        public void Display()
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    Console.Write(map[i, j]);
                    Console.Write(' ');

                }
                Console.WriteLine();
            }
        }
    }
}
