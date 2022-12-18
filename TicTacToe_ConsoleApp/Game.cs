using System;
using System.Collections.Generic;
using System.Linq;
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

        public MoveResults MakeMove(int field, char sign)
        {
            if (field < -1 || field > 8)
                return MoveResults.Forbidden;

            if (GameBoard[field] != ' ')
                return MoveResults.Occupied;

            GameBoard[field] = sign;
            return MoveResults.Done;
        }

        public GameResult CheckWin()
        {
            if (!GameBoard.Any(x => x == ' '))
                return GameResult.Draw;

            foreach (var winCondition in _winConditions)
            {
                if (GameBoard[winCondition[0]] == GameBoard[winCondition[1]] && GameBoard[winCondition[0]] == GameBoard[winCondition[2]])
                {
                    if (GameBoard[winCondition[0]] == ' ')
                        break;

                    return GameBoard[winCondition[0]] == 'O' ? GameResult.WinO : GameResult.WinX;
                }
            }

            return GameResult.NoWin;
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
