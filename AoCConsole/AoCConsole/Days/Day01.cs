using AoCConsole.Helpers;

namespace AoCConsole.Days
{
    /// <summary>
    /// --- Day 1: Calorie Counting ---
    /// </summary>
    public class Day01
    {
        public Day01()
        {
            Console.WriteLine("Day 1:");

            StarOne(InputHelper.GetInput("day01.txt")); // answer: 69836
            StarTwo(InputHelper.GetInput("day01.txt")); // answer: 207968

        }

        public void StarOne(string[] input)
        {
            double highestSum = 0;
            double elfSum = 0;
            var groupedInputs = InputHelper.ConvertToListGroup(input);

            foreach (var elf in groupedInputs)
            {
                foreach (var cal in elf.group)
                {
                    elfSum += cal;
                }

                highestSum = highestSum > elfSum ? highestSum : elfSum;
                elfSum = 0;
            }

            Console.WriteLine("Result: " + highestSum);
        }

        public void StarTwo(string[] input)
        {
            var groupedInputs = InputHelper.ConvertToListGroup(input);
            var topList = new List<(int elf, double sum)>(3) { (0, 0), (0, 0), (0, 0) };

            foreach (var elf in groupedInputs)
            {
                double currentElfSum = 0;
                foreach (var cal in elf.group)
                {
                    currentElfSum += cal;
                }

                int topListIndex = 3;
                for (int i = 2; i >= 0; i--)
                {
                    if (currentElfSum > topList[i].sum)
                    {
                        topListIndex--;
                    }
                    else
                    {
                        break;
                    }

                }
                if (topListIndex < 3)
                {
                    topList.Insert(topListIndex, (elf.index, currentElfSum));
                }
            }

            var sum = topList[0].sum + topList[1].sum + topList[2].sum;
            Console.WriteLine("Result: " + sum);
        }
    }
}
