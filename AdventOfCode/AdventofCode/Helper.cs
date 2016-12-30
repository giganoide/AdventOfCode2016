using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Helper
    {
        public static string[] SplitLines(this string input)
        {
            return input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        }
    }
}
