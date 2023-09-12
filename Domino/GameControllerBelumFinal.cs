       
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
        _arena = new Arena();
        _gameMode = GameMode.drawmode;
        _validSideTiles = new List<int>();
        _tileOnArena = new List<Tile>();
        _verticalTileOnArena = new List<Tile>();
    }
    /// <summary>
    /// adding player to the dominoes game when player was created
    /// adding player also add player with tile in dictionary _playerREsource
    /// </summary>
    /// <param name="player">player will have List of tile when adding to the game</param>
    /// <returns></returns>
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
    /// <summary>
    /// generating tile from bone yard if it available
    /// </summary>
    /// <param name="player">target generate tile to they hand</param>
    /// <param name="count">total tile will player pick</param>
    /// <returns></returns>
     // public bool GenerateTiles(IPlayer player, int count)
       public bool GenerateTiles(IPlayer player, int count)
        {
            if (_deck.GetTilesDeck().Count >= count && _playerData != null)
            {
                for (int i = 0; i < count; i++)
                { 
                    Tile tileData = _deck.GetTileData();
                    List<Tile>tiles = new();
                    if (tileData != null)
                    {
                        int a = tileData.GetTileSide1();
                        int b = tileData.GetTileSide2();
                        tiles.Add(new Tile(a, b));
                        _playerData[player].Add(tileData);
                        _deck.RemoveData(tileData);
                    }
                    else
                    {
                        return false; // Not enough tiles in the deck
                    }
                }
                return true;
            }
            return false; // Player or deck not found       
            }
    public bool CheckBoneyardAvailable()
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

    //method for insert tile on board

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
    public bool GameEndWithZeroTile()////
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

    /// <summary>
    /// this method to validate all valid tiles that player can move
    /// if no valid tile in player tile game management will not give player a chance to move
    /// </summary>
    /// <param name="player">check all tile players</param>
    /// <returns>true if at least have one valid tile to place on board</returns> <summary>
    /// 
    /// </summary>
    /// <param name="player"></param>
    /// <returns>false if all tile did't have valid number with valid side</returns>
    public bool ValidMove(IPlayer player)
    {
        //logger.Info("game checking player tile to for they move");
        foreach (var thisTile in _playerData[player])
        {
            if (_tileOnArena.Count == 0)
            {
                return true;
            }
            else if (thisTile.GetTileSide1() == _validSideTiles[0] || thisTile.GetTileSide2() == _validSideTiles[0])
            {
                return true;
            }
            else if (thisTile.GetTileSide2() == _validSideTiles[1] || thisTile.GetTileSide2() == _validSideTiles[1])
            {
                return true;
            }
            else if (_verticalTileOnArena.Count != 0)
            {
                if (thisTile.GetTileSide1() == _validSideTiles[2] || thisTile.GetTileSide2() == _validSideTiles[2])
                {
                    return true;
                }
                if (thisTile.GetTileSide1() == _validSideTiles[3] || thisTile.GetTileSide2() == _validSideTiles[3])
                {
                    return true;
                }
            }
        }
        // logger.Info("player did't have valid tile for move");
        return false;
    }
}
