using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode
{
    public class Day3
    {
        public static int Calc(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            var triangles = new List<Triangle>();
            foreach (var line in lines)
            {
                var l = line.TrimStart(' ');
                var sides = l.Split(' ').ToList();
                sides.RemoveAll(x => x == string.Empty);
                triangles.Add(new Triangle(sides.ToList()));
            }
            return triangles.Count(x => x.IsValid);
        }
    }

    public class Triangle
    {
        public int A { get; }
        public int B { get; }
        public int C { get; }
        public bool IsValid { get { return A + B > C; } }

        public Triangle(List<string> sides)
        {
            Debug.Assert(sides.Count == 3);
            var sidesInt = sides.Select(x => Convert.ToInt32(x)).ToList();
            sidesInt.Sort();
            A = sidesInt[0];
            B = sidesInt[1];
            C = sidesInt[2];
        }
    }
}
