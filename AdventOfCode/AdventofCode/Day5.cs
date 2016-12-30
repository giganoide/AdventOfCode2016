using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day5
    {
        public static string GetMed5(string input)
        {
            return GetMd5Hash(MD5.Create(), input);
        }

        public class PasswordChar
        {
            public string Char { get; }
            public long Value { get; }

            public PasswordChar(string c, long value)
            {
                Char = c;
                Value = value;
            }
        }
        
        public static PasswordChar GetPasswordChar(long start, string input, string startKey = "00000")
        {
            var md5 = string.Empty;
            start--;
            while (!md5.StartsWith(startKey))
            {
                start++;
                md5 = GetMd5Hash(MD5.Create(), input + start);
            }
            return new PasswordChar(md5.Substring(5, 1), start);
        }

        public static string GetPassword(string input)
        {
            var builder = new StringBuilder();
            long n = 0;
            while (builder.Length < 8)
            {
                var result = GetPasswordChar(n, input);
                n = result.Value + 1;
                builder.Append(result.Char);
            }
            return builder.ToString();
        }
        
        public static string GetMd5Hash(HashAlgorithm md5Hash, string input)
        {
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();
            foreach (var b in data)
                sBuilder.Append(b.ToString("x2"));
            return sBuilder.ToString();
        }
    }
}
