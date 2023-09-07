using System;
using System.Collections.Generic;

namespace Domino
{
    public class Display
    {
        public static void DisplayPlayerTiles(List<Tile> tiles)
        {
            for (int i = 0; i < tiles.Count; i++)
            {
                Console.Write($"({i}) {tiles[i].Side1}|{tiles[i].Side2} ");
            }
            Console.WriteLine();
        }

        public static void DrawBoard(IBoard board, List<Tile> tilesHorizontal, List<Tile> tilesVertical)
        {
            int cellSize = 5;
            int boardSize = board.GetBoardSize();

            Console.WriteLine($"Setting board boundary condition: {boardSize}");
            Console.WriteLine(new string('-', (cellSize + 1) * boardSize + 1));

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Tile matchingTile = FindMatchingTile(tilesHorizontal, j, i) ?? FindMatchingTile(tilesVertical, j, i);

                    if (matchingTile != null)
                    {
                        Console.Write(GetTileDisplay(matchingTile));
                    }
                    else
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

        private static Tile FindMatchingTile(List<Tile> tiles, int posX, int posY)
        {
            foreach (var tile in tiles)
            {
                int x = tile.TilePosition?.GetPosX() ?? -1;
                int y = tile.TilePosition?.GetPosY() ?? -1;

                if (x == posX && y == posY)
                {
                    return tile;
                }
            }
            return null;
        }

        private static string GetTileDisplay(Tile tile)
        {
            if (tile.Orientation == TileOrientation.Horizontal)
            {
                return $" {tile.Side1}|{tile.Side2} ";
            }
            else if (tile.Orientation == TileOrientation.Vertical)
            {
                return $" {tile.Side1}/{tile.Side2} ";
            }
            return string.Empty;
        }
    }
}
