using System;
using AdventOfCode;
using NUnit.Framework;

namespace AdventOfCodeTest
{
    [TestFixture()]
    public class Day5Test
    {
        [TestCase("00000155f8105dff7f56ee10fa9b9abd", "abc3231929")]
        public void GetMd5Test(string expected, string input)
        {
            Assert.AreEqual(expected, Day5.GetMed5(input));
        }

        [TestCase("0", 0, "abc")]
        [TestCase("9", 3231930, "abc")]
        [TestCase("e", 5017309, "abc")]
        [TestCase("5", 5278569, "abc")]
        [TestCase("3", 0, "wtnhxymk")]
        public void GetPasswordChar(string expected, long start, string input)
        {
            Assert.AreEqual(expected, Day5.GetPasswordChar(start, input, "0").Char);
        }
        
        /*
        [TestCase("1", 0, "abc")]
        [TestCase("8", 3231930, "abc")]
        [TestCase("f", 5017309, "abc")]
        [TestCase("4", 5278569, "abc")]
        [TestCase("2", 0, "wtnhxymk")]
        [Category("AcceptanceTest")]
        public void GetPasswordChar(string expected, long start, string input)
        {
            Assert.AreEqual(expected, Day5.GetPasswordChar(start, input).Char);
        }

        [TestCase("18f47a30", "abc")]
        [TestCase("2414bc77", "wtnhxymk")]
        [Category("AcceptanceTest")]
        public void GetPasswordTest(string expected, string input)
        {
            Assert.AreEqual(expected, Day5.GetPassword(input));
        }
        */
    }
}
