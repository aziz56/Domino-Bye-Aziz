 namespace Domino;
    public class Deck
    {
        private List<Tile> _tilesDeck = new List<Tile>();
        private int _totalSide;
        public Deck(int totalSide)
        {
            _totalSide = totalSide;
            _tilesDeck = new List<Tile>();
            CreateTiles();
            Shuffle();
        }
        public void CreateTiles()
        {
            HashSet<Tile> uniqueTiles = new HashSet<Tile>();

            for (int side1 = 0; side1 <= _totalSide; side1++)
            {
                for (int side2 = side1; side2 <= 6; b++)
                {
                    Tile tile = new Tile(side1, side2);
                    
                    if (uniqueTiles.Add(tile))
                    {
                        _tilesDeck.Add(tile);
                    }
                }
            }
            //Buat player langsung ambil langsung kartunya
            //buat method dengan return valuenya dia berhasil atau tidak
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
    }
