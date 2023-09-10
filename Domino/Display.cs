using System.Collections.Generic;
using Domino;
namespace DisplayDomino;
public class Display
{
    public static void DisplayPlayerTiles(List<Tile> tiles)
    {
        int tileIndex = 0;
        for (int i = 0; i < tiles.Count; i++)
        {
            Console.Write($"({i}) {tiles[tileIndex].GetTileSide1()}|{tiles[tileIndex].GetTileSide2()} ");
            tileIndex++;
        }
        Console.WriteLine();
    }
    public static void DrawBoard(IArena arena, List<Tile> tilesHorizontal, List<Tile> tilesVertical)
    {
        int cellSize = 5;
        int boardSize = arena.GetBoardSize();

        Console.WriteLine($"Setting board boundary condition: {boardSize}");
        Console.WriteLine(new string('-', (cellSize + 1) * boardSize + 1));

        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
            {
                bool tileFound = false;

                foreach (var tile in tilesHorizontal)
                {
                    int x = tile.GetTilePosition().GetPosX();
                    int y = tile.GetTilePosition().GetPosY();

                    if (x == j && y == i)
                    {
                        tileFound = true;

                        if (tile.GetTileOrientation() == TileOrientation.horizontal)
                        {
                            Console.Write($" {tile.GetTileSide1()}|{tile.GetTileSide2()} ");
                        }
                        else if (tile.GetTileOrientation() == TileOrientation.vertical)
                        {
                            Console.Write($" {tile.GetTileSide1()}/{tile.GetTileSide2()} ");
                        }
                        break;
                    }
                }

                if (!tileFound)
                {
                    foreach (var tile in tilesVertical)
                    {
                        int a = tile.GetTilePosition().GetPosX();
                        int b = tile.GetTilePosition().GetPosY();

                        if (a == j && b == i)
                        {
                            tileFound = true;

                            if (tile.GetTileOrientation() == TileOrientation.horizontal)
                            {
                                Console.Write($" {tile.GetTileSide1()}|{tile.GetTileSide2()} ");
                            }
                            else if (tile.GetTileOrientation() == TileOrientation.vertical)
                            {
                                Console.Write($" {tile.GetTileSide1()}/{tile.GetTileSide2()} ");
                            }
                            break;
                        }
                    }
                }

                if (!tileFound)
                {
                    Console.Write(new string(' ', cellSize));
                }

                Console.Write("|");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', (cellSize + 1) * boardSize + 1));
        }
        Console.WriteLine();
    }
}


