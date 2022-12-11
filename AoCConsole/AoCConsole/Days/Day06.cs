using AoCConsole.Helpers;

namespace AoCConsole.Days
{
    /// <summary>
    /// --- Day 6: Tuning Trouble ---
    ///         Radio Gaga
    /// </summary>
    internal class Day06
    {
        internal Day06()
        {
            Console.WriteLine("Day 6:");

            StarOne(InputHelper.GetInput("day06.txt")); // answer: 1598
            StarTwo(InputHelper.GetInput("day06.txt")); // answer: 2414
        }

        private void StarOne(string[] input)
        {
            int bufferSize = 4;
            var radioMessage = input[0].ToCharArray();
            var index = bufferSize - 1;

            while (index < input[0].Length)
            {
                if (NoDuplicates(input[0].Substring(index - (bufferSize - 1), bufferSize)))
                {
                    index++;
                    break;
                }
                index++;
            }

            Console.WriteLine("Result: " + index);
        }

        private bool NoDuplicates(string s)
        {
            var x = s.Distinct().Count() == s.Length;
            return x;
        }

        private void StarTwo(string[] input)
        {
            int bufferSize = 14;
            var radioMessage = input[0].ToCharArray();
            var index = bufferSize - 1;

            while (index < input[0].Length)
            {
                if (NoDuplicates(input[0].Substring(index - (bufferSize - 1), bufferSize)))
                {
                    index++;
                    break;
                }
                index++;
            }

            Console.WriteLine("Result: " + index);
        }
    }
}