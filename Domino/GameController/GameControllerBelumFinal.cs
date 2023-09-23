
namespace Domino;
public partial class GameController
{

    //variabel that game runner needed
    private List<IPlayer> _players;
    private Dictionary<IPlayer, List<Tile>> _playerData;
    private IArena _arena;
    private Deck _deck;
    private GameMode _gameMode;
    private IPlayer? _currentPlayer;
    private List<int> _validSideTiles;
    private List<Tile> _tileOnArena;
    private List<Tile> _verticalTileOnArena;

    //constructor game runner
    public GameController()
    {
        _players = new List<IPlayer>();
        _playerData = new Dictionary<IPlayer, List<Tile>>();
        _arena = new Arena();
        _deck = new Deck();
        _gameMode = GameMode.drawmode;
        _currentPlayer = null;
        _validSideTiles = new List<int>();
        _tileOnArena = new List<Tile>();
        _verticalTileOnArena = new List<Tile>();

    }
    public GameController(IPlayer player, List<Tile> tile)
    {
        _players = new List<IPlayer>();
        _playerData = new Dictionary<IPlayer, List<Tile>>();
        _playerData.Add(player, tile);
        _arena = new Arena();
        _gameMode = GameMode.drawmode;
        _validSideTiles = new List<int>();
        _tileOnArena = new List<Tile>();
        _verticalTileOnArena = new List<Tile>();
    }

    public bool AddPlayer(IPlayer player)
    {
        if (player != null)
        {
            _players?.Add(player);
            List<Tile> tilesPlayer = new List<Tile>();
            _playerData.Add(player, tilesPlayer);
            return true;
        }
        return false;
    }
    public bool AddDeck(Deck deck)
    {
        if (deck != null)
        {
            _deck = deck;
            return true;
        }
        return false;
    }
    public bool AddArena(IArena arena)
    {
        if (arena != null)
        {
            _arena = arena;
            return true;
        }
        return false;
    }
    public void SetGameMode(GameMode gameMode)
    {
        _gameMode = gameMode;
    }
    public GameMode GetGameMode()
    {
        return _gameMode;
    }
      public bool GenerateTiles(IPlayer player, int count)
    {
  
        if (_deck.GetTilesDeck()?.Count >= count && _playerData != null)
        {
            for (int i = 0; i < count; i++)
            {
                foreach (var Player in _playerData.Keys)
                {
                    if (player == Player && count != 0)
                    {
                        List<int>? tileData = _deck.GetTileData();
                        int a = tileData[0];
                        int b = tileData[1];
                        _playerData[player].Add(new Tile(a, b));
                        _deck.RemoveData(tileData);

                    }
                }
            }
            return true;
        }
        return false;
    }
    public bool CheckDeck()
    {
        if (_deck.GetTilesDeck()?.Count != 0)
        {
            return true;
        }
        return false;
    }
    public List<IPlayer> GetPlayers()
    {
        return _players;
    }

    public List<Tile> GetPlayerTiles(IPlayer player)
    {
        return _playerData[player];
    }
    public IPlayer? GetCurrentPlayer()
    {
        return _currentPlayer;
    }
    public void SetCurrentPlayer(int index)
    {
        _currentPlayer = _players[index];
    }


    public void Turn()
    {
        if (_currentPlayer != null)
        {
            int currentPLayerIndex = _players.IndexOf(_currentPlayer);
            if (currentPLayerIndex >= 0 && currentPLayerIndex < _players.Count - 1)
            {
                _currentPlayer = _players[currentPLayerIndex + 1];
            }
            else
            {
                _currentPlayer = _players[0];
            }
        }
    }
    public IArena GetArena()
    {
        return _arena;
    }
    public List<Tile> GetTileOnBoard()
    {
        return _tileOnArena;
    }
    public List<Tile> GetTileVerticalOnArena()
    {
        return _verticalTileOnArena;
    }
    public bool GameEndWithZeroTile()
    {
        foreach (var playerTile in _playerData.Values)
        {
            if (playerTile.Count == 0)
            {
                return true;
            }
        }
        return false;
    }
    private bool GameEndWithNoSameTiles(int validTile)
    {
        bool thisPlayerValidTiles = false;
        foreach (var playerTile in _playerData.Values)
        {
            foreach (var tile in playerTile)
            {
                if (tile.GetTileSide1() == validTile || tile.GetTileSide2() == validTile)
                {
                    thisPlayerValidTiles = true;
                }
            }
            if (thisPlayerValidTiles)
            {
                return false;
            }
        }
        if (!thisPlayerValidTiles)
        {
            return true;
        }
        return false;
    }

    public bool ValidMove(IPlayer player)
    {

        if (_tileOnArena.Count == 0)
        {
            return true;
        }

        int leftValue = _validSideTiles[0];
        int rightValue = _validSideTiles[1];
        int topValue = _verticalTileOnArena.Count > 0 ? _validSideTiles[3] : -1;
        int bottomValue = _verticalTileOnArena.Count > 0 ? _validSideTiles[2] : -1;
        foreach (var tile in _playerData[player])
        {
            int side1 = tile.GetTileSide1();
            int side2 = tile.GetTileSide2();
            if (side1 == leftValue || side1 == rightValue || side1 == topValue || side1 == bottomValue ||
                side2 == leftValue || side2 == rightValue || side2 == topValue || side2 == bottomValue)
            {
                return true;
            }
        }
        return false;

    }
}
