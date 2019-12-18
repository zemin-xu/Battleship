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

            Ship ship1 = new Ship("biggest ship", 5);
            ships.Add(ship1);
            Ship ship2 = new Ship("smallest ship", 2);
            ships.Add(ship2);

            foreach (Ship s in ships)
            {
                PlaceShip(s);
            }

            

            

        }

        public void PlaceShip(Ship ship)
        {
            Console.WriteLine("Please place " + ship.Name + " with a length of " + ship.Len + " onto your sea.");
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

            Console.WriteLine((int)(x - 47));
            Console.WriteLine((int)(y - 64));
            Console.WriteLine(dir);
            Console.WriteLine(dir2);



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
