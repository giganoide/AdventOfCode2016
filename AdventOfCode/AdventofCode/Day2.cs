namespace AdventOfCode
{
    public class Day2
    {
        public static int Unlock(int start, string input)
        {
            var commands = input.ToCharArray();
            var actualButton = start;
            foreach (var command in commands)
                actualButton = SendCommand(actualButton, command);
            return actualButton;
        }

        public static int SendCommand(int start, char command)
        {
            if (start == 1 && (command == 'L' || command == 'U'))
                return start;
            if (start == 2 && command == 'U')
                return start;
            if (start == 3 && (command == 'R' || command == 'U'))
                return start;
            if (start == 4 && command == 'L')
                return start;
            if (start == 6 && command == 'R')
                return start;
            if (start == 7 && (command == 'L' || command == 'D'))
                return start;
            if (start == 8 && command == 'D')
                return start;
            if (start == 9 && (command == 'D' || command == 'R'))
                return start;
            switch (command)
            {
                case 'U':
                    return start - 3;
                case 'D':
                    return start + 3;
                case 'L':
                    return start - 1;
                case 'R':
                    return start + 1;
                default:
                    return start;
            }
        }
    }
}
