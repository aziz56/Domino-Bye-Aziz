namespace Domino
{
    public class Tile : ITile
    {
        private int _side1;
        private int _side2;
        private TileOrientation _orientation;
        private Position _positionTile;

        public Tile(int side1, int side2)
        {
            SetTileValue(side1, side2);
            _positionTile = new Position();
        }

        public int Side1 => _side1;
        public int Side2 => _side2;
        public TileOrientation Orientation => _orientation;
        public Position? TilePosition => _positionTile;

        public bool SetTileValue(int side1, int side2)
        {
            if (side1 >= 0 && side2 >= 0)
            {
                _side1 = side1;
                _side2 = side2;
                return true;
            }
            return false;
        }

        public void FlipTiles()
        {
            _side1 = _side1 - _side2;
            _side2 = _side1 + _side2;
            _side1 = _side1 - _side1;
        }

        public bool SetTileOrientation(TileOrientation orientation)
        {
            if (orientation == TileOrientation.horizontal || orientation == TileOrientation.vertical)
            {
                _orientation = orientation;
                return true;
            }
            return false;
        }

        public void SetTilePosition(int x, int y)
        {
            _positionTile.SetPosition(x, y);
        }

        public override string ToString()
        {
            return $"({_side1}, {_side2})";
        }
    }
}
