﻿using AoCConsole.Helpers;

namespace AoCConsole.Days
{
    enum Score
    {
        Win = 6,
        Draw = 3,
        Loss = 0,
    }

    enum Moves
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3,
        Default = 0
    }


    public class Day2
    {
        public Day2()
        {
            StarOne(InputHelper.GetInput("day2.txt"));
            StarTwo(InputHelper.GetInput("day2.txt"));
        }

        private void StarOne(string[] input)
        {
            var matches = InputHelper.ConvertToTuple(input);
            var totalScore = 0;

            foreach (var round in matches)
            {
                var p2 = GetMove(round.player2);
                var matchResult = IsWin(GetMove(round.player1), p2);

                totalScore += (int)matchResult + (int)p2;
            }

            Console.WriteLine("Result: " + totalScore);
        }

        private Moves GetMove(string move)
        {
            // A = Rock, B = Paper, C = Scissors
            // X = Rock, Y = Paper, Z = Scissors
            switch (move)
            {
                case "X":
                case "A":
                    return Moves.Rock;
                case "Y":
                case "B":
                    return Moves.Paper;
                case "Z":
                case "C":
                    return Moves.Scissors;
            }
            return Moves.Default;
        }

        private Score IsWin(Moves enemyMove, Moves ourMove)
        {
            Score score = Score.Win;
            switch (ourMove)
            {
                case Moves.Rock:
                    if (enemyMove == Moves.Paper) score = Score.Loss;
                    else if (enemyMove == Moves.Rock) score = Score.Draw;
                    break;
                case Moves.Paper:
                    if (enemyMove == Moves.Scissors) score = Score.Loss;
                    else if (enemyMove == Moves.Paper) score = Score.Draw;
                    break;
                case Moves.Scissors:
                    if (enemyMove == Moves.Rock) score = Score.Loss;
                    if (enemyMove == Moves.Scissors) score = Score.Draw;
                    break;
            }
            return score;
        }

        private void StarTwo(string[] input)
        {
            // X = Lose, Y = Draw, Z = Win

            var matches = InputHelper.ConvertToTuple(input);
            var totalScore = 0;

            foreach (var round in matches)
            {
                var p1 = GetMove(round.player1);
                //p2 = ??
                var matchResult = Score.Loss;

                switch (round.player2)
                {
                    case "X":
                        matchResult = Score.Loss;
                        break;
                    case "Y":
                        matchResult = Score.Draw;
                        break;
                    case "Z":
                        matchResult = Score.Win;
                        break;
                    default:
                        break;
                }

                totalScore += (int)matchResult + (int)GetScriptedMove(p1, matchResult);
            }

            Console.WriteLine("Result: " + totalScore);
        }

        private Moves GetScriptedMove(Moves elf, Score isWin)
        {
            var myMove = Moves.Default;
            switch (isWin)
            {
                case Score.Win:
                    if (elf == Moves.Scissors) myMove = Moves.Rock;
                    else if (elf == Moves.Rock) myMove = Moves.Paper;
                    else if (elf == Moves.Paper) myMove = Moves.Scissors;
                    break;
                case Score.Draw:
                    myMove = elf;
                    break;
                case Score.Loss:
                    if (elf == Moves.Scissors) myMove = Moves.Paper;
                    else if (elf == Moves.Rock) myMove = Moves.Scissors;
                    else if (elf == Moves.Paper) myMove = Moves.Rock;
                    break;
                default:
                    break;
            }
            return myMove;
        }
    }
}