namespace Domino
{
    public class Tile : ITile
    {
        private int _side1;
        private int _side2;

        private TileOrientation _orientation;
        private Position _positionTile;


        public Tile(int Side1, int Side2)
        {
            SetTileValue(Side1, Side2);
            _positionTile = new();

        }
        public int GetTileSide1()
        {
            return _side1;
        }
        public int GetTileSide2()
        {
            return _side2;
        }
        public bool SetTileValue(int Side1, int Side2)
        {
            if (Side1 >=0 && Side2 >= 0)
            {
                _side2 = Side2;
                _side1 = Side1;
                return true;
            }
                return false;
        }
        public override string ToString()
        {
            return $"({_side1}, {_side2})";
        }
        public bool FlipTiles()
    {
        if (_side1 >= 0 && _side2 >= 0)
        {
            int temp = _side1;
            _side1 = _side2;
            _side2 = temp;
            return true;
        }
        return false;
    }
        public bool SetTileOrientation(TileOrientation orientation)
    {
        if (TileOrientation.horizontal == orientation || TileOrientation.vertical == orientation)
        {
            _orientation = orientation;
            return true;
        }
        return false;
    }
    public TileOrientation GetTileOrientation()
    {
        return _orientation;
    }
    public Position? GetTilePosition()
    {
        return _positionTile;
    }
    public void SetTilePosition(int x, int y)
    {
        _positionTile.SetPosition(x, y);
    }
}
    }