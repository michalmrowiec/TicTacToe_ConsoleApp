using TicTacToe_ConsoleApp;

var game = new Game();

Console.Clear();
game.ShowGameBoard();

while (true)
{
    Console.WriteLine("Gracz O");

    while(true)
    {
        var move = game.MakeMove(int.Parse(Console.ReadLine()), 'O');
        if(move == MoveResults.Done)
            break;
        else
            Console.WriteLine(move);
    }

    Console.Clear();
    game.ShowGameBoard();

    if (game.CheckWin() != GameResult.NoWin)
    {
        Console.WriteLine(game.CheckWin());
        break;
    }

    Console.WriteLine("Gracz X");
    while (true)
    {
        var move = game.MakeMove(int.Parse(Console.ReadLine()), 'X');
        if (move == MoveResults.Done)
            break;
        else
            Console.WriteLine(move);
    }

    Console.Clear();
    game.ShowGameBoard();

    if (game.CheckWin() != GameResult.NoWin)
    {
        Console.WriteLine(game.CheckWin());
        break;
    }
}