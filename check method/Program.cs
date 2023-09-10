using System;
using System.Collections.Generic;

class DominoTile
{
    public int Side1 { get; }
    public int Side2 { get; }

    public DominoTile(int side1, int side2)
    {
        Side1 = side1;
        Side2 = side2;
    }

    public DominoTile Flip()
    {
        return new DominoTile(Side2, Side1);
    }

    public override string ToString()
    {
        return $"[{Side1}|{Side2}]";
    }
}

class Program
{
    static void Main()
    {
        // Generate a set of double-six dominoes
        List<DominoTile> tiles = GenerateDoubleSixDominoes();

        List<DominoTile> matchedTiles = new List<DominoTile>();

        while (tiles.Count > 0)
        {
            bool foundMatch = false;

            for (int i = 0; i < tiles.Count; i++)
            {
                DominoTile tile = tiles[i];

                if (matchedTiles.Count == 0 || tile.Side1 == matchedTiles[0].Side1 || tile.Side2 == matchedTiles[0].Side1)
                {
                    matchedTiles.Insert(0, tile);
                    tiles.RemoveAt(i);
                    foundMatch = true;
                    break;
                }
                else if (matchedTiles.Count == 0 || tile.Side1 == matchedTiles[0].Side2 || tile.Side2 == matchedTiles[0].Side2)
                {
                    matchedTiles.Insert(0, tile.Flip());
                    tiles.RemoveAt(i);
                    foundMatch = true;
                    break;
                }
            }

            if (!foundMatch)
            {
                Console.WriteLine("No more matches can be found.");
                break;
            }
        }

        Console.Write("Matched Tiles: ");
        foreach (DominoTile tile in matchedTiles)
        {
            Console.Write(tile + " ");
        }
    }

    static List<DominoTile> GenerateDoubleSixDominoes()
    {
        List<DominoTile> doubleSixDominoes = new List<DominoTile>();

        for (int i = 0; i <= 6; i++)
        {
            for (int j = i; j <= 6; j++)
            {
                doubleSixDominoes.Add(new DominoTile(i, j));
            }
        }

        return doubleSixDominoes;
    }
}
