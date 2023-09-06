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
        public bool SetTileValue(int side1, int side2)
        {
            if (side1 >=0 && side2 >= 0)
            {
                _side2 = side2;
                _side1 = side1;
                return true;
            }
                return false;
        }
        public override string ToString()
        {
            return $"({_side1}, {_side2})";
        }
    }


}
//Jangan buat public
//Flipnya dibuat di GC