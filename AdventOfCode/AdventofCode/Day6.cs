using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Day6
    {
        public static string GetCode(string messages)
        {
            var lines = messages.SplitLines();
            var code = new StringBuilder();
            for (var i = 0; i < lines[0].Length; i++)
                code.Append(GetMostFrequentChar(lines, i));
            return code.ToString();
        }

        private static char GetMostFrequentChar(string[] messages, int charIndex)
        {
            var builder = new StringBuilder();
            foreach (var message in messages)
                builder.Append(message.ToCharArray()[charIndex]);
            return builder.ToString().GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
        }
    }
}
