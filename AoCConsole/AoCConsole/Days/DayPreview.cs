using AoCConsole.Helpers;

namespace AoCConsole.Days
{
    /// <summary>
    /// prep work
    /// </summary>
    internal class DayPreview
    {
        internal DayPreview()
        {
            Console.WriteLine("Day preview:");

            StarOne(InputHelper.GetInput("test.txt")); // answer: preview
            StarTwo(InputHelper.GetInput("test.txt")); // answer: preview
        }

        private void StarOne(string[] input)
        {
            string result = "";

            Console.WriteLine("Result: " + result);
        }

        private void StarTwo(string[] input)
        {
            string result = "";

            Console.WriteLine("Result: " + result);
        }
    }
}
