using AoCConsole.Helpers;

namespace AoCConsole.Days
{
    /// <summary>
    /// Day 9: Rope Bridge
    ///     Snake?
    /// </summary>
    internal class Day9
    {
        internal Day9()
        {
            StarOne(InputHelper.GetInput("day9.txt"));
            StarTwo(InputHelper.GetInput("test.txt"));
            StarTwo(InputHelper.GetInput("day9.txt"));
        }

        private void StarOne(string[] input)
        {
            var snakeHead = new SnakePosition((0, 0));
            var snakeTail = new SnakePosition((0, 0));
            snakeTail.Dirty = true;
            var executedTailMoves = new List<(int x, int y)>() { (snakeTail.X, snakeTail.Y) };

            foreach (var moves in input)
            {
                var move = moves.Split();
                for (int i = 0; i < int.Parse(move[1]); i++)
                {
                    //snakeHead move
                    snakeHead.Move(move[0][0]);

                    //snakeTail move
                    if (MoveTail(snakeTail, snakeHead))
                    {
                        executedTailMoves.Add((snakeTail.X, snakeTail.Y));
                    }
                }
            }

            string result = executedTailMoves.Distinct().Count().ToString();

            Console.WriteLine("Result: " + result); // 6011
        }

        private bool IsConnected()
        {
            return false;
        }

        private int GetDifference(int head, int tail)
        {
            int result = head - tail;
            if (result < 0)
            {
                result *= -1;
            }
            return result;
        }

        private bool MoveTail(SnakePosition tail, SnakePosition head)
        {
            var diffX = GetDifference(tail.X, head.X);
            var diffY = GetDifference(tail.Y, head.Y);

            if (diffX > 1)
            {
                if (head.X > tail.X) tail.X++;
                else if (head.X < tail.X) tail.X--;

                if (diffY > 0)
                {
                    if (head.Y > tail.Y) tail.Y++;
                    else if (head.Y < tail.Y) tail.Y--;
                }
            }

            if (diffY > 1)
            {
                if (head.Y > tail.Y) tail.Y++;
                else if (head.Y < tail.Y) tail.Y--;

                if (diffX > 0)
                {
                    if (head.X > tail.X) tail.X++;
                    else if (head.X < tail.X) tail.X--;
                }
            }

            if (diffX > 1 || diffY > 1)
            {
                return true;
            }

            return false;
        }

        private void StarTwo(string[] input)
        {
            var snake = new List<SnakePosition>()
            {
                new SnakePosition((0, 0)),
                new SnakePosition((0, 0)),
                new SnakePosition((0, 0)),
                new SnakePosition((0, 0)),
                new SnakePosition((0, 0)),
                new SnakePosition((0, 0)),
                new SnakePosition((0, 0)),
                new SnakePosition((0, 0)),
                new SnakePosition((0, 0)),
                new SnakePosition((0, 0))
                        };

            var executedTailMoves = new List<(int x, int y)>() { (0, 0) };

            foreach (var row in input)
            {
                var move = row.Split();

                // moves per row
                for (int i = 0; i < int.Parse(move[1]); i++)
                {
                    //snakeHead move
                    snake[0].Move(move[0][0]);

                    //move tail x bodylenght
                    for (int p = 1; p < snake.Count(); p++)
                    {
                        //snakeTail move
                        var moved = MoveTail(snake[p], snake[p - 1]);
                        if (moved && p == 9)
                        {
                            executedTailMoves.Add((snake[p].X, snake[p].Y));
                        }
                        else if (!moved)
                        {
                            break;
                        }
                    }
                }
            }

            string result = executedTailMoves.Distinct().Count().ToString();

            Console.WriteLine("Result: " + result);
        }
    }

    internal class SnakePosition
    {
        public SnakePosition((int x, int y) position)
        {
            X = position.x;
            Y = position.y;
        }

        internal (int x, int y) Move(char step)
        {
            switch (step)
            {
                case 'U':
                    Y++;
                    break;
                case 'D':
                    Y--;
                    break;
                case 'L':
                    X--;
                    break;
                case 'R':
                    X++;
                    break;
                default:
                    break;
            }
            return (X, Y);
        }

        public int X { get; set; }
        internal int Y { get; set; }
        internal bool Dirty { get; set; }
    }
}
