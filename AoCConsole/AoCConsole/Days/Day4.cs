using AoCConsole.Helpers;

namespace AoCConsole.Days
{
    internal class Day4
    {
        internal Day4()
        {
            StarOne(InputHelper.GetInput("day4.txt"));
            StarTwo(InputHelper.GetInput("day4.txt"));
        }

        private void StarOne(string[] input)
        {
            var cleanupPairs = InputHelper.ConvertToTuple(input, delimiter: new char[] { ',' });
            var totalScore = 0;

            foreach (var pair in cleanupPairs)
            {
                var elfA = pair.a.Split('-');
                var elfB = pair.b.Split('-');

                if (CheckContainmentStarOne(elfA, elfB))
                {
                    totalScore++;
                }
            }

            Console.WriteLine("Result: " + totalScore);
        }

        private bool CheckContainmentStarOne(string[] elfA, string[] elfB)
        {
            int elfAa = int.Parse(elfA[0]);
            int elfAb = int.Parse(elfA[1]);
            int elfBa = int.Parse(elfB[0]);
            int elfBb = int.Parse(elfB[1]);

            // B contains whole A
            if (elfAa >= elfBa && elfAb <= elfBb)
            {
                return true;
            }
            // A contains whole B
            if (elfBa >= elfAa && elfBb <= elfAb)
            {
                return true;
            }
            return false;
        }


        private void StarTwo(string[] input)
        {
            var cleanupPairs = InputHelper.ConvertToTuple(input, delimiter: new char[] { ',' });
            var totalScore = 0;

            foreach (var pair in cleanupPairs)
            {
                var elfA = pair.a.Split('-');
                var elfB = pair.b.Split('-');

                if (CheckContainmentStarTwo(elfA, elfB))
                {
                    totalScore++;
                }
            }

            Console.WriteLine("Result: " + totalScore);
        }

        private bool CheckContainmentStarTwo(string[] elfA, string[] elfB)
        {
            int elfAa = int.Parse(elfA[0]);
            int elfAb = int.Parse(elfA[1]);
            int elfBa = int.Parse(elfB[0]);
            int elfBb = int.Parse(elfB[1]);


            // B contains Astart
            if (elfAa >= elfBa && elfAa <= elfBb)
            {
                return true;
            }
            // B contains Aend
            if (elfAb >= elfBa && elfAb <= elfBb)
            {
                return true;
            }

            // A contains Bstart
            if (elfBa >= elfAa && elfBa <= elfAb)
            {
                return true;
            } // A contains Bend
            if (elfBb >= elfAa && elfBb <= elfAb)
            {
                return true;
            }

            return false;
        }
    }
}
