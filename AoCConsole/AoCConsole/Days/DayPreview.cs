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
            StarOne(InputHelper.GetInput("test.txt"));
            StarTwo(InputHelper.GetInput("test.txt"));
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
