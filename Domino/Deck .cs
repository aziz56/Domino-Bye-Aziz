using System;
using System.Collections.Generic;

namespace Domino
{
    public class Deck
    {
        private List<List<int>> _tilesDeck;
        private int _totalSide;

        public Deck(int totalSide)
        {
            _tilesDeck = new List<List<int>>();
            _totalSide = totalSide;
            CreateTiles();
            Shuffle();
        }

        public Deck()
        {

        }

        public void CreateTiles()
        {
            for (int Side1 = 0; Side1 <= _totalSide; Side1++)
            {
                for (int Side2 = Side1; Side2 <= _totalSide; Side2++)
                {
                    List<int> tiles = new List<int>() { Side1, Side2 };
                    _tilesDeck.Add(tiles);
                }
            }
        }

        public bool Shuffle()
        {
            if (_tilesDeck.Count >= 2)
            {
                Random rng = new Random();
                int n = _tilesDeck.Count;
                while (n > 1)
                {
                    n--;
                    int indexRand = rng.Next(n + 1);
                    List<int> value = _tilesDeck[indexRand];
                    _tilesDeck[indexRand] = _tilesDeck[n];
                    _tilesDeck[n] = value;
                }
                return true;
            }
            return false;
        }
        public List<List<int>>? GetTilesDeck()
        {
            return _tilesDeck;
        }
        public List<int>? GetTileData()
        {
            if (_tilesDeck.Count > 0)
            {
                List<int> data = _tilesDeck[0];
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
                if (_tilesDeck.Contains(data))
                {
                    _tilesDeck.Remove(data);
                    return true;
                }
            }
            return false;
        }
    }
}
