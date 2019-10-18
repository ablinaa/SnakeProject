using PixelEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Snack
{
    public class ExampleSnake : ISnake
    {
        private const int _width = 50;
        private const int _wallDistanceThreshold = 5;
        private Point _myHeadPosition;
        private Point foodPosition;

        public string Name => "Example Snake";

        public SnakeDirection GetNextDirection(SnakeDirection currentDirection)
        {
            if(_myHeadPosition.Y == foodPosition.Y && _myHeadPosition.X < foodPosition.X)
            {
                return SnakeDirection.Right;
            }

            if (_myHeadPosition.Y == foodPosition.Y && _myHeadPosition.X > foodPosition.X)
            {
                return SnakeDirection.Left;
            }

            if (_myHeadPosition.X == foodPosition.X && _myHeadPosition.Y > foodPosition.Y)
            {
                return SnakeDirection.Up;
            }

            if (_myHeadPosition.X == foodPosition.X && _myHeadPosition.Y < foodPosition.Y)
            {
                return SnakeDirection.Down;
            }

            if (currentDirection == SnakeDirection.Up
                && _myHeadPosition.Y < _wallDistanceThreshold)
            {
                return SnakeDirection.Left;
            }


            if(currentDirection == SnakeDirection.Right
                && _myHeadPosition.X > _width - _wallDistanceThreshold)
            {
                return SnakeDirection.Up;
            }

            if(currentDirection == SnakeDirection.Down
                && _myHeadPosition.Y > _width - _wallDistanceThreshold)
            {
                return SnakeDirection.Right;
            }

            if (currentDirection == SnakeDirection.Left
                && _myHeadPosition.X <  _wallDistanceThreshold)
            {
                return SnakeDirection.Down;
            }

            return currentDirection;
        }

        public void UpdateMap(string map)
        {
            _myHeadPosition = getMyHeadPosition(map);
            foodPosition = getFoodPosition(map);
        }

        private Point getMyHeadPosition(string map)
        {
            var headIndex = map.IndexOf('*');
            return new Point(headIndex % _width, headIndex / _width);
        }

        private Point getFoodPosition(string map)
        {
            var foodIndex = map.IndexOf("7");
            return new Point(foodIndex % _width, foodIndex / _width); 
        }
    }
}
