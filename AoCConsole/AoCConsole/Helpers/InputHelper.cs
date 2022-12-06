namespace AoCConsole.Helpers
{
    public static class InputHelper
    {
        public static string[] GetInput(string fileName)
        {
            string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName + "/Inputs/", fileName);
            return File.ReadAllLines(path);
        }

        public static Queue<string> ConvertToQueue(this string[] input)
        {
            return new Queue<string>(input);
        }

        public static List<(string a, string b)> ConvertToTuple(this string[] input, char[] delimiter)
        {
            var result = new List<(string, string)>();
            foreach (var row in input)
            {
                if (row != null)
                {
                    var x = row.Split(delimiter);
                    result.Add((x[0], x[1]));
                }
            }
            return result;
        }

        public static List<(int index, List<int> group)> ConvertToListGroup(this string[] input)
        {
            var groupedInput = new List<(int index, List<int> group)>();
            var group = new List<int>();
            int elfIndex = 0;

            foreach (var row in input)
            {
                if (string.IsNullOrWhiteSpace(row))
                {
                    groupedInput.Add((elfIndex, group));
                    group = new List<int>();
                    elfIndex++;
                    continue;
                }
                else
                {
                    group.Add(int.Parse(row.Trim()));
                }
            }
            groupedInput.Add((elfIndex, group));

            return groupedInput;
        }
    }
}
