using AoCConsole.Helpers;

namespace AoCConsole.Days
{
    /// <summary>
    /// --- Day 10: Cathode-Ray Tube ---
    /// </summary>
    internal class Day10
    {
        internal Day10()
        {
            Console.WriteLine("Day 10:");

            StarOne(InputHelper.GetInput("day10.txt")); // answer: 11780
            StarTwo(InputHelper.GetInput("day10.txt")); // answer: PZULBAUA
        }

        private void StarOne(string[] input)
        {
            int x = 1;
            int result = 0;
            var core1 = new Queue<int>();
            var stopPoints = new HashSet<int>() { 20, 60, 100, 140, 180, 220 };

            //load commands
            LoadCommands(input, core1);

            // Execute commands
            for (int cycle = 1; 0 < core1.Count; cycle++)
            {
                //cycle action
                if (stopPoints.Contains(cycle))
                {
                    result += (x * cycle);
                }

                // cycle complete
                var command = core1.Dequeue();
                x += command;
            }

            Console.WriteLine("Result: " + result);
        }

        private void LoadCommands(string[] input, Queue<int> instructions)
        {
            //load commands
            foreach (var inputRow in input)
            {
                var row = inputRow.Split();

                if (row[0] == "addx")
                {
                    instructions.Enqueue(0);
                    instructions.Enqueue(int.Parse(row[1]));
                }
                else
                // noop
                {
                    instructions.Enqueue(0);
                }
            }
        }

        private void StarTwo(string[] input)
        {
            var CRTHeight = 6;
            var CRTWidth = 40;
            var currentCRTHeightPos = -1;
            var currentCRTWidthPos = 0;
            var CRT = new List<List<string>>()
            {
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>()
            };

            int x = 1;
            int cycle = 0;
            var core1 = new Queue<int>();

            LoadCommands(input, core1);

            for (int i = 0; i < (CRTHeight * CRTWidth); i++)
            {
                // Screen position
                if (i % 40 == 0)
                {
                    currentCRTHeightPos++;
                    currentCRTWidthPos = 0;
                    cycle = 0;
                }

                // Draw action
                if (GetDifference(x, cycle) <= 1)
                {
                    CRT[currentCRTHeightPos].Add("#");
                }
                else
                {
                    CRT[currentCRTHeightPos].Add(".");
                }


                // Cycle complete
                var command = core1.Dequeue();
                x += command;
                currentCRTWidthPos++;
                cycle++;
            }

            // draw
            PrintResult(CRT);
        }

        private void PrintResult(List<List<string>> crt)
        {
            Console.WriteLine();
            Console.WriteLine("START");
            foreach (var line in crt)
            {
                foreach (var pos in line)
                {
                    Console.Write(pos);
                }
                Console.WriteLine();
            }
            Console.WriteLine("END!");
        }

        private int GetDifference(int x, int y)
        {
            int result = x - y;
            if (result < 0)
            {
                result *= -1;
            }
            return result;
        }
    }
}
