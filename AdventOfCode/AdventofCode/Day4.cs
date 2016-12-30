using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Day4
    {
        public static int CountCheckSumValid(string encryptedNames)
        {
            var lines = encryptedNames.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            var rooms = new List<Room>();
            foreach (var line in lines)
            {
                var l = line.TrimStart(' ');
                rooms.Add(new Room(l));
            }
            return rooms.Where(x => x.IsValid()).Sum(x => x.Id);
        }

        public static bool CheckEncryptName(string encryptedName)
        {
            return new Room(encryptedName).IsValid();
        }

        private class Room
        {
            private string name;
            public int Id;
            private string checksum;

            public Room(string encryptedName)
            {
                var i = encryptedName.IndexOf('[');
                var j = encryptedName.LastIndexOf('-');
                checksum = encryptedName.Substring(i+1, 5);
                var sId = encryptedName.Substring(j+1, i - j-1);
                Id = Convert.ToInt32(sId);
                name = encryptedName.Substring(0, j).Replace("-", string.Empty);
            }

            public bool IsValid()
            {
                var chars = new Dictionary<char, int>();
                foreach (var c in name.ToCharArray())
                {
                    if (!chars.ContainsKey(c))
                        chars.Add(c,0);
                    chars[c]++;
                }
                var charList = chars.ToList().OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToList();
                
                var builder = new StringBuilder();
                for (var i = 0; i < 5; i++)
                    builder.Append(charList[i].Key);
                var checksumCalculated = builder.ToString();
                return checksum == checksumCalculated;
            }
        }
    }
}
