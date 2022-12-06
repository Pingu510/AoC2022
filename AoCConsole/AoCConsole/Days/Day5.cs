using AoCConsole.Helpers;

namespace AoCConsole.Days
{
    /// <summary>
    /// --- Day 5: Supply Stacks ---
    /// </summary>
    internal class Day5
    {
        internal Day5()
        {
            StarOne(InputHelper.GetInput("day5.txt"));
            StarTwo(InputHelper.GetInput("day5.txt"));
        }

        private void StarOne(string[] input)
        {
            var stackStart = input.TakeWhile(x => x != string.Empty).ToList();
            var moveRows = input.Skip(stackStart.Count() + 1);
            var stacks = GetStacks(stackStart);


            foreach (var move in moveRows)
            {
                var m = new Move(move);

                for (int i = 0; i < m.CratesToMove; i++)
                {
                    stacks[m.ToStack].Push(stacks[m.FromStack].Pop());
                }
            }

            string result = "";
            stacks.ForEach(s => result += s.Peek());

            Console.WriteLine("Result: " + result);
        }

        /// <summary>
        /// Get the stacks from right index
        /// </summary>
        /// <param name="stackStart"></param>
        /// <returns></returns>
        private List<Stack<char>> GetStacks(List<string> stackStart)
        {
            var stacks = new List<Stack<char>>();
            stackStart.Last().Split().ToList().Where(x => !String.IsNullOrEmpty(x)).ToList().ForEach(stackId =>
            {
                var index = stackStart.Last().IndexOf(stackId);
                var stack = new Stack<char>();
                stackStart.ForEach(row =>
                {
                    if (row[index] != ' ')
                    {
                        stack.Push(row[index]);
                    }
                });
                stack.Reverse();
                stacks.Add(new Stack<char>(stack));
            });
            return stacks;
        }

        private void StarTwo(string[] input)
        {
            var stackStart = input.TakeWhile(x => x != string.Empty).ToList();
            var moveRows = input.Skip(stackStart.Count() + 1);
            var stacks = GetStacks(stackStart);

            foreach (var move in moveRows)
            {
                var m = new Move(move);
                var movedCrates = new List<char>();
                for (int i = 0; i < m.CratesToMove; i++)
                {
                    movedCrates.Add(stacks[m.FromStack].Pop());
                }

                // add in reverse
                movedCrates.Reverse();
                foreach (var item in movedCrates)
                {
                    stacks[m.ToStack].Push(item);
                }
            }

            string result = "";
            stacks.ForEach(s => result += s.Peek());

            Console.WriteLine("Result: " + result);
        }


    }

    internal class Move
    {
        public int CratesToMove { get; set; }
        public int FromStack { get; set; }
        public int ToStack { get; set; }

        public Move(string row)
        {
            var move = row.Split(new string[] { " ", "move", "from", "to" }, StringSplitOptions.RemoveEmptyEntries);
            CratesToMove = int.Parse(move[0]);
            FromStack = int.Parse(move[1]) - 1;
            ToStack = int.Parse(move[2]) - 1;
        }
    }
}
