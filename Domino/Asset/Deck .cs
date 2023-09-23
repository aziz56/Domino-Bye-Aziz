using System.Collections.Generic;
namespace Domino;

public class Deck
{
    private List<List<int>>? _tilesOnDeck;
    private int _totalSide;

    public Deck(int totalSide)
    {
        _tilesOnDeck = new List<List<int>>();
        _totalSide = totalSide;
        CreateDominoTiles();
        ShuffleTiles();
    }
    public Deck()
    {

    }
    protected void CreateDominoTiles()
    {
        for (int side1 = 0; side1 <= _totalSide; side1++)
        {
            for (int side2 = side1; side2 <= _totalSide; side2++)
            {
                List<int> tile = new List<int> { side1, side2 };
                _tilesOnDeck?.Add(tile);

            }
        }
    }
    public bool ShuffleTiles()
    {
        if (_tilesOnDeck?.Count >= 2)
        {
            Random rondom = new Random();
            int n = _tilesOnDeck.Count;
            while (n > 1)
            {
                n--;
                int randomIndex = rondom.Next(n + 1);
                List<int> value = _tilesOnDeck[randomIndex];
                _tilesOnDeck[randomIndex] = _tilesOnDeck[n];
                _tilesOnDeck[n] = value;
            }
            return true;
        }
        return false;
    }
    public List<List<int>>? GetTilesDeck()
    {
        return _tilesOnDeck;
    }
    public List<int>? GetTileData()
    {
        if (_tilesOnDeck?.Count > 0)
        {
            List<int> data = _tilesOnDeck[0];
            return data;
        }
        else
        {
            return null;
        }
    }
    public bool RemoveData(List<int> data)
    {
        if (_tilesOnDeck != null)
        {
            _tilesOnDeck.Remove(data);
            return false;
        }
        return false;
    }

}

