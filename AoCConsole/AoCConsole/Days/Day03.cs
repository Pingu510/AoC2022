using AoCConsole.Helpers;

namespace AoCConsole.Days
{
    /// <summary>
    /// --- Day 3: Rucksack Reorganization ---
    /// </summary>
    internal class Day03
    {
        static private List<char> letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToList();

        internal Day03()
        {
            Console.WriteLine("Day 3:");

            StarOne(InputHelper.GetInput("day03.txt")); // answer: 8088
            StarTwo(InputHelper.GetInput("day03.txt")); // answer: 2522
        }

        private void StarOne(string[] input)
        {
            var totalScore = 0;

            foreach (var pack in input)
            {
                var packLen = pack.Length;

                var conpartmentA = pack.Substring(0, packLen / 2);
                var conpartmentB = pack.Substring(startIndex: packLen / 2);

                var duplicate = conpartmentA.Intersect(conpartmentB).ToHashSet<char>();
                totalScore += GetPriorityScore(duplicate.FirstOrDefault());
            }

            Console.WriteLine("Result: " + totalScore);
        }

        private int GetPriorityScore(char duplicate)
        {
            return letters.IndexOf(duplicate) + 1;
        }

        private void StarTwo(string[] input)
        {
            var queue = input.ConvertToQueue();
            var totalScore = 0;

            while (queue.Count > 2)
            {
                var duplicate = CompareSet(queue.Dequeue(), queue.Dequeue(), queue.Dequeue());
                totalScore += GetPriorityScore(duplicate);
            }

            Console.WriteLine("Result: " + totalScore);
        }

        private char CompareSet(string elfA, string elfB, string elfC)
        {
            var duplicate = elfA.Intersect(elfB).Intersect(elfC).ToHashSet<char>();
            return duplicate.FirstOrDefault();
        }
    }
}
