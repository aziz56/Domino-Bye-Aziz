// using System.Collections.Generic;
// namespace Domino;

// public class Deck
// {
//     private List<List<int>>? _tilesOnDeck;
//     private int _totalSide;

//     public Deck(int totalSide)
//     {
//         _tilesOnDeck = new List<List<int>>();
//         _totalSide = totalSide;
//         CreateDominoTiles();
//         ShuffleTiles();
//     }
//     public Deck()
//     {

//     }
//     protected void CreateDominoTiles()
//     {
//         for (int sideA = 0; sideA <= _totalSide; sideA++)
//         {
//             for (int sideB = sideA; sideB <= _totalSide; sideB++)
//             {
//                 List<int> tile = new List<int> { sideB, sideA };
//                 _tilesOnDeck?.Add(tile);
//             }
//         }
//     }
//     public bool ShuffleTiles()
//     {
//         if (_tilesOnDeck?.Count >= 2)
//         {
//             Random rondom = new Random();
//             int n = _tilesOnDeck.Count;
//             while (n > 1)
//             {
//                 n--;
//                 int randomIndex = rondom.Next(n + 1);
//                 List<int> value = _tilesOnDeck[randomIndex];
//                 _tilesOnDeck[randomIndex] = _tilesOnDeck[n];
//                 _tilesOnDeck[n] = value;
//             }
//             return true;
//         }
//         return false;
//     }
//     public List<List<int>>? GetTilesDeck()
//     {
//         return _tilesOnDeck;
//     }
//     public List<int>? GetTileData()
//     {
//         if (_tilesOnDeck?.Count > 0)
//         {
//             List<int> data = _tilesOnDeck[0];
//             return data;
//         }
//         else
//         {
//             return null;
//         }
//     }
//     public bool RemoveData(List<int> data)
//     {
//         if (_tilesOnDeck != null)
//         {
//             _tilesOnDeck.Remove(data);
//             return false;
//         }
//         return false;
//     }

// }
// using System;
// using System.Collections.Generic;

namespace Domino
{
    public class Deck
    {
        private List<Tile> _tilesDeck;
        private int _totalSide;
        

        public Deck(int totalSide)
        {
            _tilesDeck = new List<Tile>();
            _totalSide = totalSide;
            CreateTiles();
            Shuffle();
        }

        public Deck()
        {
            _tilesDeck = new List<Tile>();
        }

        public void CreateTiles()
        {
            for (int Side1 = 0; Side1 <= _totalSide; Side1++)
            {
                for (int Side2 = Side1; Side2 <= _totalSide; Side2++)
                {
                    Tile _tile = new Tile(Side1,Side2);
                    _tilesDeck.Add(_tile);
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
                    Tile value = _tilesDeck[indexRand];
                    _tilesDeck[indexRand] = _tilesDeck[n];
                    _tilesDeck[n] = value;
                }
                return true;
            }
            return false;
        }
        
        public List<Tile>? GetTilesDeck()
        {
            return _tilesDeck;
        }
        public Tile GetTileData()
        {
            if (_tilesDeck?.Count > 0)
            {
                Tile data = _tilesDeck[0];
                return data ;
            }
            else
            {
                return null;
            }
        }

        public bool RemoveData(Tile data)
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
