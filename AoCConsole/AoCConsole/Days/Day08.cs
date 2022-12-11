using AoCConsole.Helpers;

namespace AoCConsole.Days
{
    /// <summary>
    /// --- Day 8: Treetop Tree House ---
    ///         Matrix sightlines
    /// </summary>
    internal class Day08
    {
        internal Day08()
        {
            Console.WriteLine("Day 8:");

            StarOne(InputHelper.GetInput("day08.txt")); // answer: 1733
            StarTwo(InputHelper.GetInput("day08.txt")); // answer: 284648
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

            for (int i = 0; i < matrix.Count; i++) // Column
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
                tree.VisibleFromNorth = true; // doesnt matter which
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

        private int GetMaxScenicScore(List<List<Tree>> trees)
        {
            int score = 0;
            foreach (var row in trees)
            {
                foreach (var tree in row)
                {
                    score = score < tree.ScenicScore ? tree.ScenicScore : score;
                }
            }
            return score;
        }

        private void LookHorizontalScenic(List<Tree> trees, (int row, int col) position, Tree potentialTreehouse)
        {
            // west
            for (int i = position.col - 1; 0 <= i; i--)
            {
                if (trees[i].Height < potentialTreehouse.Height)
                {
                    potentialTreehouse.VisibleTreesWest++;
                }
                else
                {
                    potentialTreehouse.VisibleTreesWest++;
                    break;
                }
            }

            // east
            for (int i = position.col + 1; i < trees.Count(); i++)
            {
                if (trees[i].Height < potentialTreehouse.Height)
                {
                    potentialTreehouse.VisibleTreesEast++;
                }
                else
                {
                    potentialTreehouse.VisibleTreesEast++;
                    break;
                }
            }
        }

        private void LookVerticalScenic(List<Tree> trees, (int row, int col) position, Tree potentialTreehouse)
        {
            // north
            for (int i = position.row - 1; 0 <= i; i--)
            {
                if (trees[i].Height < potentialTreehouse.Height)
                {
                    potentialTreehouse.VisibleTreesNorth++;
                }
                else
                {
                    potentialTreehouse.VisibleTreesNorth++;
                    break;
                }
            }

            // south
            for (int i = position.row + 1; i < trees.Count(); i++)
            {
                if (trees[i].Height < potentialTreehouse.Height)
                {
                    potentialTreehouse.VisibleTreesSouth++;
                }
                else
                {
                    potentialTreehouse.VisibleTreesSouth++;
                    break;
                }
            }
        }

        private void StarTwo(string[] input)
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
                matrix.Add(row);
            }

            var reverseMatrix = new List<List<Tree>>();
            for (int i = 0; i < matrix.Count; i++)//Column
            {
                var treeColumn = new List<Tree>();
                foreach (var row in matrix)
                {
                    treeColumn.Add(row[i]);
                }
                reverseMatrix.Add(treeColumn);
            }

            for (int row = 3; row < matrix[0].Count; row++)
            {
                for (int col = 2; col < matrix.Count; col++)
                {
                    LookHorizontalScenic(matrix[row], (row, col), matrix[row][col]);
                    LookVerticalScenic(reverseMatrix[col], (row, col), matrix[row][col]);
                }
            }

            int result = GetMaxScenicScore(matrix);
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

        public int VisibleTreesEast { get; set; } = 0;
        public int VisibleTreesWest { get; set; } = 0;
        public int VisibleTreesNorth { get; set; } = 0;
        public int VisibleTreesSouth { get; set; } = 0;

        public int ScenicScore => VisibleTreesEast * VisibleTreesWest * VisibleTreesNorth * VisibleTreesSouth;

        public bool Visible => VisibleFromNorth || VisibleFromSouth || VisibleFromWest || VisibleFromEast;
    }
}
