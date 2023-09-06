 namespace Domino;
    public class Deck
    {
        public List<Tile> _tiles = new List<Tile>();

        public Deck()
        {
            HashSet<Tile> uniqueTiles = new HashSet<Tile>();

            for (int a = 0; a <= 6; a++)
            {
                for (int b = a; b <= 6; b++)
                {
                    Tile tile = new Tile(a, b);
                    
                    if (uniqueTiles.Add(tile))
                    {
                        _tiles.Add(tile);
                    }
                }
            }
            //Buat player langsung ambil langsung kartunya
            //buat method dengan return valuenya dia berhasil atau tidak
        }

        // public void Shuffle()
        // {
        //     Random rng = new Random();
        //     int n = _tiles.Count;
        //     while (n > 1)
        //     {
        //         n--;
        //         int k = rng.Next(n + 1);
        //         Tile value = _tiles[k];
        //         _tiles[k] = _tiles[n];
        //         _tiles[n] = value;
        //     }
        // }
    }
