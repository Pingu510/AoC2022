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
            return File.ReadAllLines(fileName);
        }

        public static List<int> ConvertToList(this string[] input)
        {
            return new List<int>();
        }

        public static List<(int index, List<int> group)> ConvertToListGroup(this string[] input)
        {
            return new List<(int index, List<int> group)>();
        }
    }
}
