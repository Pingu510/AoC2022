using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCConsole.Helpers
{
    public static class InputHelper
    {
        public static string[] GetInput(string fileName)
        {
            string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName + "/Inputs/", fileName);
            return File.ReadAllLines(path);
        }

        public static List<int> ConvertToList(this string[] input)
        {
            return new List<int>();
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
