using CreatureAndField_2;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace CreatureAndField
{
    public enum Direction
    {
        North = 0,
        East = 1,
        South = 2,
        West = 3
    }

    public class Creature: IMoveStrategy
    {
        private Point _pos;
        private Direction _currentDirection;
        private string _name;
        private IField _iField;
        private int _moves;

        public Creature(Point pos, string name, IField iField)
        {
            _pos = pos;
            _currentDirection = Direction.East;
            _name = name;
            _iField = iField;
            _moves = 0;
        }

        public bool NextMove()
        {
            _iField.PaintTheCell(_pos, _moves);
            int turnCounter = 0;
            while (turnCounter < 4)
            {
                Point nextPos = NextCell();
                if (_iField.CanMove(nextPos))
                {
                    _pos = nextPos;
                    _moves++;
                    return true;
                }
                Turn();
                turnCounter++;
            }
            return false;
        }

        private void Turn()
        {
            _currentDirection = (Direction)(((int)_currentDirection + 1) % 4);
        }

        private Point NextCell()
        {
            switch (_currentDirection)
            {
                case Direction.North:
                    return new Point(_pos.X, _pos.Y + 1);
                case Direction.East:
                    return new Point(_pos.X + 1, _pos.Y);
                case Direction.South:
                    return new Point(_pos.X, _pos.Y - 1);
                case Direction.West:
                    return new Point(_pos.X - 1, _pos.Y);
                default:
                    return _pos;
            }
        }

        public override string ToString()
        {
            return $"{_name}: {_pos.ToString()}, direction: {_currentDirection.ToString()}. Marked {_moves.ToString()}"; 
        }
    }
}
