using AoCConsole.Helpers;

namespace AoCConsole.Days
{
    /// <summary>
    /// --- Day 11: Monkey in the Middle ---
    ///             **** monkeys
    /// </summary>
    internal class Day11
    {
        internal Day11()
        {
            Console.WriteLine("Day 11:");

            StarOne(InputHelper.GetInput("day11.txt")); // answer: 57838
            StarTwo(InputHelper.GetInput("day11.txt")); // answer: 15050382231
        }

        private void StarOne(string[] input)
        {
            // load Monkeys
            List<Monkey> monkeys = LoadMonkeyInput(input);

            // round
            for (int round = 1; round <= 20; round++)
            {
                DoOneRound(monkeys);
                //PrintRoundResults(round, monkeys);
            }

            //Console.WriteLine();
            //PrintInspectionResult(monkeys);
            //Console.WriteLine();

            var u = monkeys.OrderByDescending(x => x.ItemsInspected).Take(2);
            Console.WriteLine($"Result: {u.First().ItemsInspected} * {u.Last().ItemsInspected} = " + u.First().ItemsInspected * u.Last().ItemsInspected);
        }

        void PrintRoundResults(int round, List<Monkey> monkeys)
        {
            Console.WriteLine("Round: " + round);

            for (int i = 0; i < monkeys.Count; i++)
            {
                Console.Write($"Monkey {i}: ");
                foreach (var item in monkeys[i].Items)
                {
                    Console.Write(item + ", ");
                }
                Console.WriteLine();
            }
        }

        void PrintInspectionResult(List<Monkey> monkeys)
        {
            for (int i = 0; i < monkeys.Count; i++)
            {
                Console.WriteLine($"Monkey {i}: inspected items {monkeys[i].ItemsInspected} times.");
            }
        }

        private List<Monkey> LoadMonkeyInput(string[] input)
        {
            List<Monkey> monkeys = new List<Monkey>();
            int rowIndex = 0;
            int index = 0;
            while (true)
            {
                List<string> monkeyValues = new List<string>();
                // read monkey
                for (var i = 0; i < 6; i++)
                {
                    monkeyValues.Add(input[rowIndex]);
                    rowIndex++;
                }

                var itemQueue = new Queue<double>();
                var st = new string[] { "Starting items: ", "," };
                var startingItems = monkeyValues[1].Split(st, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in startingItems)
                {
                    itemQueue.Enqueue(double.Parse(item));
                }

                var op = monkeyValues[2].Split("Operation: new = old", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                var test = monkeyValues[3].Split("Test: divisible by", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

                // create monkey
                var monkey = new Monkey(
                    itemQueue,
                    (op[0][0].ToString(), op[0].Substring(1)),
                    int.Parse(test[0]),
                    (int.Parse(monkeyValues[4].Last().ToString()), int.Parse(monkeyValues[5].Last().ToString())));

                monkeys.Add(monkey);
                index++;
                rowIndex++;
                if (input.Length < rowIndex)
                {
                    break;
                }
            }
            return monkeys;
        }

        private void StarTwo(string[] input)
        {
            // load Monkeys
            List<Monkey> monkeys = LoadMonkeyInput(input);

            var divider = monkeys[0].Test;
            for (int i = 1; i < monkeys.Count; i++)
            {
                divider *= monkeys[i].Test;
            }

            // round
            for (int round = 1; round <= 10000; round++)
            {
                DoOneRound(monkeys, divider);
            }

            PrintInspectionResult(monkeys);
            Console.WriteLine();

            var u = monkeys.OrderByDescending(x => x.ItemsInspected).Take(2);
            Console.WriteLine($"Monkeyinspections: {u.First().ItemsInspected} and {u.Last().ItemsInspected}");
            Console.WriteLine("Result: " + u.First().ItemsInspected * u.Last().ItemsInspected);
        }

        private void DoOneRound(List<Monkey> monkeys, int divide = 0)
        {
            foreach (var monkey in monkeys)
            {
                while (0 < monkey.Items.Count)
                {
                    var item = monkey.Items.Dequeue();

                    // Inspection
                    monkey.ItemsInspected++;
                    var isNum = double.TryParse(monkey.Operation.num, out double num);
                    switch (monkey.Operation.op)
                    {
                        case "*":
                            item *= isNum ? num : item;
                            break;
                        case "+":
                            item += isNum ? num : item;
                            break;
                        default:
                            break;
                    }

                    // Inspection done
                    if (divide != 0)
                    {
                        item %= divide;
                    }
                    else
                    {
                        item = (int)(item / 3d);
                    }

                    // Test
                    if (item % monkey.Test == 0)
                    {
                        monkeys[monkey.TestResult.t].Items.Enqueue(item);
                    }
                    else
                    {
                        monkeys[monkey.TestResult.f].Items.Enqueue(item);
                    }
                }
            }
        }

        private class Monkey
        {
            public Monkey(Queue<double> items, (string, string) operation, int test, (int t, int f) testResult)
            {
                ItemsInspected = 0;
                Items = items;
                Operation = operation;
                Test = test;
                TestResult = testResult;
            }

            public double ItemsInspected { get; set; }
            public Queue<double> Items { get; set; }
            public (string op, string num) Operation { get; }
            public int Test { get; }
            public (int t, int f) TestResult { get; }
        }
    }
}
