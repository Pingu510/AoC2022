using AoCConsole.Helpers;

namespace AoCConsole.Days
{
    /// <summary>
    /// --- Day 10: Cathode-Ray Tube ---
    /// </summary>
    internal class Day10
    {
        private event EventHandler CycleChanged;

        internal Day10()
        {
            StarOne(InputHelper.GetInput("day10.txt"));
            StarTwo(InputHelper.GetInput("test.txt"));
        }



        private void StarOne(string[] input)
        {
            int x = 1;
            int result = 0;
            var core1 = new Queue<int>();
            var stopPoints = new HashSet<int>() { 20, 60, 100, 140, 180, 220 };

            //load commands
            foreach (var inputRow in input)
            {
                var row = inputRow.Split();

                if (row[0] == "addx")
                {
                    core1.Enqueue(0);
                    core1.Enqueue(int.Parse(row[1]));
                }
                else
                // noop
                {
                    core1.Enqueue(0);
                }
            }

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

            Console.WriteLine("Result: " + result); //11780
        }




        private void StarTwo(string[] input)
        {
            string result = "";

            Console.WriteLine("Result: " + result);
        }
    }
}
