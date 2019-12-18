using System;
namespace Battleship
{
    public class Ship
    {
        public string Name { get; set; }
        public int Len { get; set; }

        public Ship(string n, int l)
        {
            Name = n;
            Len = l;
        }
    }
}
