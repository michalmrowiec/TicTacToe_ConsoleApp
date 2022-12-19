using TicTacToe_ConsoleApp;

var game = new Game();

Console.Clear();
game.ShowGameBoardColor();

//player to player
while (false)
{
    Console.WriteLine("Gracz O");

    while(true)
    {
        var move = game.MakeMove(game.GameBoard, int.Parse(Console.ReadLine()), 'O');
        if(move == MoveResults.Done)
            break;
        else
            Console.WriteLine(move);
    }

    Console.Clear();
    game.ShowGameBoard();

    if (game.CheckWin(game.GameBoard) != GameResult.NoWin)
    {
        Console.WriteLine(game.CheckWin(game.GameBoard));
        break;
    }

    Console.WriteLine("Gracz X");
    while (true)
    {
        var move = game.MakeMove(game.GameBoard, int.Parse(Console.ReadLine()), 'X');
        if (move == MoveResults.Done)
            break;
        else
            Console.WriteLine(move);
    }

    Console.Clear();
    game.ShowGameBoard();

    if (game.CheckWin(game.GameBoard) != GameResult.NoWin)
    {
        Console.WriteLine(game.CheckWin(game.GameBoard));
        break;
    }
}

//player to AI
while (true)
{
    //Player
    Console.WriteLine("Gracz O");

    while (true)
    {
        var move = game.MakeMove(game.GameBoard, int.Parse(Console.ReadLine()), 'O');
        if (move == MoveResults.Done)
            break;
        else
            Console.WriteLine(move);
    }

    Console.Clear();
    game.ShowGameBoardColor();

    if (game.CheckWin(game.GameBoard) != GameResult.NoWin)
    {
        Console.WriteLine(game.CheckWin(game.GameBoard));
        break;
    }

    //AI
    Console.WriteLine("Gracz X");
    game.MakeMove(game.GameBoard, game.FindBestMove(game.GameBoard), 'X');

    Console.Clear();
    game.ShowGameBoardColor();

    if (game.CheckWin(game.GameBoard) != GameResult.NoWin)
    {
        Console.WriteLine(game.CheckWin(game.GameBoard));
        break;
    }
}