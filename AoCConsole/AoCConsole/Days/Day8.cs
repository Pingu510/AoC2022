using AoCConsole.Helpers;

namespace AoCConsole.Days
{
    /// <summary>
    /// prep work
    /// </summary>
    internal class Day8
    {
        internal Day8()
        {
            StarOne(InputHelper.GetInput("test.txt"));
            StarOne(InputHelper.GetInput("day8.txt"));
            StarTwo(InputHelper.GetInput("test.txt"));
        }

        private void StarOne(string[] input)
        {
            var matrix = new List<List<Tree>>();
            for (int i = 0; i < input.Length; i++)
            {
                var row = new List<Tree>();
                var inputRow = input[i];
                for (int j = 0; j < inputRow.Length; j++)
                {
                    row.Add(new Tree(int.Parse(inputRow[j].ToString())));
                }
                LookHorizontal(row);
                matrix.Add(row);
            }

            for (int i = 0; i < matrix.Count; i++)//Column
            {
                var treeColumn = new List<Tree>();
                foreach (var row in matrix)
                {
                    treeColumn.Add(row[i]);
                }

                if (i == 0 || i == matrix.Count - 1)
                {
                    SetVisible(treeColumn);
                    continue;
                }

                LookVertical(treeColumn);
            }

            SetVisible(matrix[0]);
            SetVisible(matrix[input.Length - 1]);

            int result = GetTotalVisibility(matrix);
            Console.WriteLine("Result: " + result);
        }

        private void LookVertical(List<Tree> trees)
        {
            int treeCount = trees.Count();

            // north
            trees[0].VisibleFromNorth = true;
            int neighbourHeight = trees[0].Height;
            for (int i = 1; i < treeCount; i++)
            {
                if (trees[i].Height > neighbourHeight)
                {
                    neighbourHeight = trees[i].Height;
                    trees[i].VisibleFromNorth = true;
                }
                else if (neighbourHeight >= 9)
                {
                    break;
                }
            }

            // south
            trees[treeCount - 1].VisibleFromSouth = true;
            neighbourHeight = trees[treeCount - 1].Height;
            for (int i = treeCount - 1; 0 <= i; i--)
            {
                if (trees[i].Height > neighbourHeight)
                {
                    neighbourHeight = trees[i].Height;
                    trees[i].VisibleFromSouth = true;
                }
                else if (neighbourHeight >= 9)
                {
                    break;
                }
            }
        }

        private void LookHorizontal(List<Tree> trees)
        {
            int treeCount = trees.Count();

            // west
            trees[0].VisibleFromWest = true;
            int neighbourHeight = trees[0].Height;
            for (int i = 1; i < treeCount; i++)
            {
                if (trees[i].Height > neighbourHeight)
                {
                    neighbourHeight = trees[i].Height;
                    trees[i].VisibleFromWest = true;
                }
                else if (neighbourHeight >= 9)
                {
                    break;
                }
            }

            // east
            trees[treeCount - 1].VisibleFromEast = true;
            neighbourHeight = trees[treeCount - 1].Height;
            for (int i = treeCount - 1; 0 <= i; i--)
            {
                if (trees[i].Height > neighbourHeight)
                {
                    neighbourHeight = trees[i].Height;
                    trees[i].VisibleFromWest = true;
                }
                else if (neighbourHeight >= 9)
                {
                    break;
                }
            }
        }

        private void SetVisible(List<Tree> trees)
        {
            foreach (var tree in trees)
            {
                tree.VisibleFromNorth = true;//doesnt matter
            }
        }

        private int GetTotalVisibility(List<List<Tree>> trees)
        {
            int score = 0;
            foreach (var row in trees)
            {
                foreach (var tree in row)
                {
                    score += tree.Visible ? 1 : 0;
                }
            }
            return score;
        }

        private void StarTwo(string[] input)
        {
            string result = "";

            Console.WriteLine("Result: " + result);
        }
    }

    internal class Tree
    {
        public Tree(int height)
        {
            Height = height;
        }

        public int Height { get; set; }
        public bool VisibleFromEast { get; set; }
        public bool VisibleFromWest { get; set; }
        public bool VisibleFromNorth { get; set; }
        public bool VisibleFromSouth { get; set; }

        public bool Visible => VisibleFromNorth || VisibleFromSouth || VisibleFromWest || VisibleFromEast;
    }
}
