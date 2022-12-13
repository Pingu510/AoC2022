using AoCConsole.Helpers;

namespace AoCConsole.Days
{
	/// <summary>
	/// prep work
	/// </summary>
	internal class Day12
	{
		internal Day12()
		{
			Console.WriteLine("Day 12:");

			StarOne(InputHelper.GetInput("test.txt")); // answer: 
			StarTwo(InputHelper.GetInput("test.txt")); // answer: 
		}

		private void StarOne(string[] input)
		{
			char start = 'S';//a
			char end = 'E';//z

			// populate list
			var matrix = GetCharMatrix(input);

			// recur the shaite out of it
			// find shortest, skip loops
			// test = 31 steps

			string result = "";

			Console.WriteLine("Result: " + result);
		}

		List<List<FunTimesTM>> GetCharMatrix(string[] input)
		{
			var matrix = new List<List<FunTimesTM>>();
			foreach (var row in input)
			{
				var funRow = new List<FunTimesTM>();
				foreach (var letter in row)
				{
					funRow.Add(new FunTimesTM(letter));
				}
				matrix.Add(funRow);
			}

			return matrix;
		}

		private void StarTwo(string[] input)
		{
			string result = "";

			Console.WriteLine("Result: " + result);
		}

		class FunTimesTM
		{
			public FunTimesTM(char letter)
			{
				Letter = letter;
			}

			public bool Dirty { get; set; }
			public char Letter { get; set; }
		}
	}
}
