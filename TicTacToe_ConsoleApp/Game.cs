using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_ConsoleApp
{
    internal class Game
    {
        public char[] GameBoard { get; private set; }
            = new char[9] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };

        List<int[]> _winConditions = new List<int[]>
        {
            new int[] { 0, 1, 2 }, new int[]{ 3, 4, 5 }, new int[] { 6, 7, 8 },
            new int[] { 0, 3, 6 }, new int[] { 1, 4, 7 }, new int[] { 2, 5, 8 },
            new int[] { 0, 4, 8 }, new int[] { 2, 4, 6 }
        };

        public void ShowGameBoard()
        {
            Console.WriteLine($"|{GameBoard[0]}|{GameBoard[1]}|{GameBoard[2]}|  |0|1|2|");
            Console.WriteLine($"|{GameBoard[3]}|{GameBoard[4]}|{GameBoard[5]}|  |3|4|5|");
            Console.WriteLine($"|{GameBoard[6]}|{GameBoard[7]}|{GameBoard[8]}|  |6|7|8|");
        }

        public void ShowGameBoardColor()
        {
            WriteLineColoredText(new string[] { $"|{GameBoard[0]}|{GameBoard[1]}|{GameBoard[2]}|", "    |0|1|2|" },
                new ConsoleColor[] { ConsoleColor.White, ConsoleColor.DarkGray }, ConsoleColor.White);

            WriteLineColoredText(new string[] { $"|{GameBoard[3]}|{GameBoard[4]}|{GameBoard[5]}|", "    |3|4|5|" },
                new ConsoleColor[] { ConsoleColor.White, ConsoleColor.DarkGray }, ConsoleColor.White);

            WriteLineColoredText(new string[] { $"|{GameBoard[6]}|{GameBoard[7]}|{GameBoard[8]}|", "    |6|7|8|" },
                new ConsoleColor[] { ConsoleColor.White, ConsoleColor.DarkGray }, ConsoleColor.White);
        }

        public MoveResults MakeMove(char[] gameBoard, int field, char sign)
        {
            if (field < -1 || field > 8)
                return MoveResults.Forbidden;

            if (gameBoard[field] != ' ')
                return MoveResults.Occupied;

            gameBoard[field] = sign;
            return MoveResults.Done;
        }

        public GameResult CheckWin(char[] gameBoard)
        {
            foreach (var winCondition in _winConditions)
            {
                if (gameBoard[winCondition[0]] == gameBoard[winCondition[1]] && gameBoard[winCondition[0]] == gameBoard[winCondition[2]])
                {
                    if (gameBoard[winCondition[0]] == ' ')
                        break;

                    return gameBoard[winCondition[0]] == 'O' ? GameResult.WinO : GameResult.WinX;
                }
            }

            if (!gameBoard.Any(x => x == ' '))
                return GameResult.Draw;

            return GameResult.NoWin;
        }

        public int GameEwaluation(char[] gameBoard)
        {
            switch (CheckWin(gameBoard))
            {
                case GameResult.WinX:
                    return 10;
                case GameResult.WinO:
                    return -10;
                default:
                    return 0;
            }
        }

        public int MiniMax(char[] gameBoard, int depth, bool isMax)
        {
            int score = GameEwaluation(gameBoard);

            if (score == 10)
                return score;

            if (score == -10)
                return score;

            if (CheckWin(gameBoard) == GameResult.Draw)
                return 0;

            if (isMax)
            {
                int best = -1000;

                for (int i = 0; i < gameBoard.Length; i++)
                {
                    if (gameBoard[i] == ' ')
                    {
                        gameBoard[i] = 'X';

                        best = Math.Max(best, MiniMax(gameBoard, depth + 1, !isMax));

                        gameBoard[i] = ' ';
                    }
                }
                return best;
            }
            else
            {
                int best = 1000;

                for (int i = 0; i < gameBoard.Length; i++)
                {
                    if (gameBoard[i] == ' ')
                    {
                        gameBoard[i] = 'O';

                        best = Math.Min(best, MiniMax(gameBoard, depth + 1, !isMax));

                        gameBoard[i] = ' ';
                    }
                }
                return best;
            }
        }

        public int FindBestMove(char[] gameBoard)
        {
            int bestValue = -1000;
            int bestMove = -1;

            for (int i = 0; i < gameBoard.Length; i++)
            {
                if (gameBoard[i] == ' ')
                {
                    gameBoard[i] = 'X';

                    int moveVal = MiniMax(gameBoard, 0, false);

                    gameBoard[i] = ' ';

                    if (moveVal > bestValue)
                    {
                        bestMove = i;
                        bestValue = moveVal;
                    }
                }
            }
            return bestMove;
        }

        public void WriteLineColoredText(string[] texts, ConsoleColor[] foregroundColors, ConsoleColor lastColor)
        {
            for (int i = 0; i < texts.Length; i++)
            {
                Console.ForegroundColor = foregroundColors[i];
                Console.Write(texts[i]);
            }
            Console.Write("\n");
            Console.ForegroundColor = lastColor;
        }
    }

    public enum MoveResults
    {
        Forbidden,
        Occupied,
        Done
    }

    public enum GameResult
    {
        WinX,
        WinO,
        Draw,
        NoWin
    }
}
