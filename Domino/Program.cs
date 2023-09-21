using System.Collections.Generic;
using System.Threading.Tasks;

using Domino;
using DisplayDomino;

class Program
{
    [Obsolete]
    public static void Main()
    {

        GameController game1 = new GameController();
      

        game1.gameEnded += handleGameEnded;
        game1.gameEnded += PlayerWin;
        game1.gameEnded += PlayerLose;

        IPlayer player1 = new Player();
        Console.WriteLine("Enter Player 1 ID:");
        int id1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Player 1 Name:");
        string name1 = Console.ReadLine();

        player1.SetID(id1);
        player1.SetName(name1);

        IPlayer player2 = new Player();
        Console.WriteLine("Enter Player 2 ID:");
        int id2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Player 2 Name:");
        string name2 = Console.ReadLine();

        player2.SetID(id2);
        player2.SetName(name2);


        Deck deck= new Deck(6);
        IArena arena = new Arena();
        arena.SetArenaSize(20);

        game1.AddArena(arena);
        game1.AddDeck(deck);
        game1.AddPlayer(player1);
        game1.AddPlayer(player2);


        game1.GenerateTiles(player1, 5);
        game1.GenerateTiles(player2, 5);
    
        game1.SetGameMode(GameMode.blockmode);
        Console.WriteLine("=====Game Start=====");
        game1.SetCurrentPlayer(0);
        while (!game1.IsEnded())
        {
            game1.GetPlayerTiles(player1);
            game1.GetPlayerTiles(player2);
            Console.Clear();
            Console.Write("waiting for validate turn and create board ");
            //Task.Delay(1000);
            Console.Write(". ");
            //Task.Delay(1000);
            Console.Write(". ");
            //Task.Delay(1000);
            Console.WriteLine(". ");
            Display.DrawBoard(arena, game1.GetTileOnBoard(), game1.GetTileVerticalOnArena());
            Console.WriteLine("=========================================");
            Console.WriteLine($"Now is {game1.GetCurrentPlayer().GetName()} Turn");
            Console.WriteLine("=========================================\n");
            Display.DisplayPlayerTiles(game1.GetPlayerTiles(game1.GetCurrentPlayer()));
            if (!game1.ValidMove(game1.GetCurrentPlayer()))
            {
                if (deck.GetTilesDeck()?.Count != 0 && game1.GetGameMode() == GameMode.drawmode)
                {
                    Console.WriteLine("you did't have same card");
                    Console.WriteLine("please pick card on boneyard");
                    game1.GenerateTiles(game1.GetCurrentPlayer(), 1);
                    Console.Write("press any key to move next player");
                    Console.ReadKey();
                    game1.Turn();
                }
                else if (deck.GetTilesDeck()?.Count == 0 || game1.GetGameMode() == GameMode.blockmode)
                {
                    Console.WriteLine("you did't have same card");
                    if (game1.GetGameMode() == GameMode.drawmode)
                    {
                        Console.WriteLine("All tiles in boneyard already taken");
                    }
                    Console.Write("press any key to move next player");
                    Console.ReadKey();
                    game1.Turn();
                }
            }
            else if (game1.ValidMove(game1.GetCurrentPlayer()))
            {
                Console.Write("Enter the tile by index (from 0) to place your tile on board : ");
                int setTilesOnBoard;
                do
                {
                    setTilesOnBoard = int.Parse(Console.ReadLine());
                    if (setTilesOnBoard < 0 || setTilesOnBoard >= game1.GetPlayerTiles(game1.GetCurrentPlayer()).Count)
                    {
                        Console.WriteLine("invalid index, please input valid index");
                    }

                }
                while (setTilesOnBoard < 0 || setTilesOnBoard >= game1.GetPlayerTiles(game1.GetCurrentPlayer()).Count);

                Console.WriteLine("Choose placement direction:");
                Console.WriteLine("1. Left");
                Console.WriteLine("2. Right");
                Console.WriteLine("3. buttom");
                Console.WriteLine("4. Top");
                Console.Write("Enter your choice: ");
                int placementChoice = int.Parse(Console.ReadLine());

                Tile selectedTile = game1.GetPlayerTiles(game1.GetCurrentPlayer())[setTilesOnBoard];
                if (placementChoice == 1)
                {
                    game1.MakeMove(selectedTile, 1);

                }
                else if (placementChoice == 2)
                {
                    game1.MakeMove(selectedTile, 2);


                }
                else if (placementChoice == 3)
                {
                    game1.MakeMove(selectedTile, 3);

                }
                else if (placementChoice == 4)
                {
                    game1.MakeMove(selectedTile, 4);

                }
                else
                {
                    Console.WriteLine("invalid choice, please enter a valid option");
                }
                Console.ReadKey();
            }
        }
        /// <summary>
        /// adding leaderboard history to json file
        /// </summary>
        /// <returns></returns>
        //still exception with keyvaluepair connot serialize
        // var leaderBoard = new DataContractJsonSerializer(typeof(List<KeyValuePair<IPlayer, int>>));
        // using (FileStream stream = new FileStream("History.json", FileMode.OpenOrCreate))
        // {
        //     leaderBoard.WriteObject(stream, game1.GetLeaderBoard());
        // }

        void handleGameEnded(object? sender, EventArgs e)
        {
            Console.WriteLine("Game was Ended");
            Console.WriteLine("==============");
            int ranking = 1;
            foreach (var player in game1.GetLeaderBoard())
            {
                Console.WriteLine($"{ranking}. {player.Key.GetName()}\ttotal tile on hand : {player.Value}");
                ranking++;
            }
            Console.WriteLine("==============");
        }
        void PlayerWin(object? sender, EventArgs e)
        {
            GameStatus status = GameStatus.winTheGame;
            IPlayer playerWin = game1.GetLeaderBoard()[0].Key;
            Console.WriteLine($"\nCongratulation {playerWin.GetName()}!!! you {status}\n");
        }
        void PlayerLose(object? sender, EventArgs e)
        {
            GameStatus status = GameStatus.loseTheGame;
            for (int i = 1; i < game1.GetLeaderBoard().Count; i++)
            {
                Console.WriteLine($"{game1.GetLeaderBoard()[i].Key.GetName()}, you {status}");
            }
        }

    }
}