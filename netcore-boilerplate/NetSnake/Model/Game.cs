using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetSnake.Model
{
    public class Game
    {
        public Guid Id;

        public int Width;

        public int Height;

        public IList<Point> Food = new List<Point>();

        public IList<Snake> Snakes = new List<Snake>();

        public IList<Snake> DeadSnakes = new List<Snake>();

        public int Turn;

        public Guid MySnakeId;
    }
}