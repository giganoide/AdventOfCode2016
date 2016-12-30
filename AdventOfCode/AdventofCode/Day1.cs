using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day1
    {
        public static int GetDistance(string input)
        {
            var stepStringList = GetStepsStringList(input);
            var steps = GetSteps(stepStringList);
            var cartesian = new Cartesian();
            foreach (var step in steps)
                cartesian.Add(step);
            return cartesian.Distance;
        }

        private static IEnumerable<string> GetStepsStringList(string indications)
        {
            return indications.Split(',').ToList().Select(x => x.Trim()).ToList();
        }

        private static IEnumerable<Step> GetSteps(IEnumerable<string> stepStringList)
        {
            var steps = new List<Step>();
            foreach (var stepString in stepStringList)
            {
                var direction = stepString.Substring(0, 1); ;
                var value = Convert.ToInt32(stepString.Remove(0, 1));
                steps.Add(new Step(direction.ToCharArray()[0], value));
            }
            return steps;
        }

        private static int CalcDistance(IEnumerable<Step> steps)
        {
            var result = steps.Select(x => x.Value).Sum();
            return result;
        }

        public class Step
        {
            public TurnCommand Command { get; }
            public int Value { get; }

            public Step(char command, int value)
            {
                Command = command == 'R' ? TurnCommand.Right : TurnCommand.Left;
                Value = value;
            }
        }

        public enum TurnCommand
        {
            Right,
            Left
        }

        public enum CardinalPoint
        {
            N,
            E,
            S,
            W
        }

        public class Cartesian
        {
            public int Distance { get { return Math.Abs(_x) + Math.Abs(_y); } }

            private CardinalPoint _direction = CardinalPoint.N;
            private int _x = 0;
            private int _y = 0;

            public void Add(Step step)
            {
                _direction = step.Command == TurnCommand.Right ? TurnRight(_direction) : TurnLeft(_direction);

                if (_direction == CardinalPoint.N)
                    _y += step.Value;
                if (_direction == CardinalPoint.E)
                    _x += step.Value;
                if (_direction == CardinalPoint.S)
                    _y -= step.Value;
                if (_direction == CardinalPoint.W)
                    _x -= step.Value;
            }

            private CardinalPoint TurnRight(CardinalPoint direction)
            {
                if (direction == CardinalPoint.N)
                    return CardinalPoint.E;
                if (direction == CardinalPoint.E)
                    return CardinalPoint.S;
                if (direction == CardinalPoint.S)
                    return CardinalPoint.W;
                if (direction == CardinalPoint.W)
                    return CardinalPoint.N;
                return CardinalPoint.N;
            }

            private CardinalPoint TurnLeft(CardinalPoint direction)
            {
                if (direction == CardinalPoint.N)
                    return CardinalPoint.W;
                if (direction == CardinalPoint.E)
                    return CardinalPoint.N;
                if (direction == CardinalPoint.S)
                    return CardinalPoint.E;
                if (direction == CardinalPoint.W)
                    return CardinalPoint.S;
                return CardinalPoint.S;
            }
        }
    }
}
