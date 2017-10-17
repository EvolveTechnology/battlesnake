using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetSnake.Model
{
    public class Snake
    {
        public Guid Id;

        public string Name;

        public string Taunt;

        public IList<Point> Coordinates = new List<Point>();

        public int Health;
    }
}