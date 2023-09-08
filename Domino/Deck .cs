using System;
using System.Collections.Generic;

namespace Domino
{
    public class Deck
    {
        private List<Tile> _tilesDeck = new List<Tile>();
        private int _totalSide;

        public Deck(int totalSide)
        {
            _totalSide = totalSide;
            CreateTiles();
            Shuffle();
        }

        public Deck()
        {
            _totalSide = 6; // Default totalSide if not specified
            CreateTiles();
            Shuffle();
        }

        public void CreateTiles()
        {
            _tilesDeck.Clear(); // Clear existing tiles before creating new ones

            HashSet<Tile> uniqueTiles = new HashSet<Tile>();

            for (int Side1 = 0; Side1 <= _totalSide; Side1++)
            {
                for (int Side2 = Side1; Side2 <= _totalSide; Side2++) // Fixed this line
                {
                    Tile tile = new Tile(Side1, Side2);

                    if (uniqueTiles.Add(tile))
                    {
                        _tilesDeck.Add(tile);
                    }
                }
            }
        }

        public void Shuffle()
        {
            Random rng = new Random();
            int n = _tilesDeck.Count;
            while (n > 1)
            {
                n--;
                int indexRand = rng.Next(n + 1);
                Tile value = _tilesDeck[indexRand];
                _tilesDeck[indexRand] = _tilesDeck[n];
                _tilesDeck[n] = value;
            }
        }

        public List<int>? GetTileData()
        {
            if (_tilesDeck.Count > 0)
            {
                List<int> data = new List<int> { _tilesDeck[0].Side1, _tilesDeck[0].Side2 }; // Fixed property names
                return data;
            }
            else
            {
                return null;
            }
        }

        public bool RemoveData(List<int> data)
        {
            if (_tilesDeck.Count > 0)
            {
                Tile tileToRemove = _tilesDeck.Find(tile => tile.Side1 == data[0] && tile.Side2 == data[1]);
                if (tileToRemove != null)
                {
                    _tilesDeck.Remove(tileToRemove);
                    return true;
                }
            }
            return false;
        }
    }
}
