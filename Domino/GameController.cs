namespace Domino;

public class GameController
{
    private Dictionary<IPlayer,ITile>_playerData;
    private List<IPlayer>_players;
    private List<ITile>_tiles;
    private Deck _deck;
    private IArena _arena;

    private IPlayer? _currentPlayer;
    private List<int> _validSideTiles;
    private List<Tile> _tileOnBoard;
    private List<Tile> _verticalTileOnBoard;

public GameController()
{
    _players = new List<IPlayer>();
    _deck = new Deck(); 
    _arena = new Arena();
    _playerData =new Dictionary<IPlayer, ITile>();
    _tiles = new List<ITile>();
}
// public GameController(Dictionary<IPlayer, ITile> playerdata)
// {
//    _players = new List<IPlayer>();
//    _player

   
// }
public bool AddPlayer(IPlayer player)
{
    if (player != null)
    {
        _players?.Add(player);
        List<Tile> tilesPlayer = new List<Tile>();
        _playerData.Add(player, (ITile)tilesPlayer);
        return true;    
    }
    return false;
}
public bool AddDeck(Deck deck) 
{
    if (_deck != null)
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

    public List<IPlayer> GetPlayers()
    {
        return _players;
    }

    public List<Tile> GetPlayerTiles(IPlayer player)
    {
        return (List<Tile>)_playerData[player];
    }
    public IPlayer? GetCurrentPlayer()
    {
        return _currentPlayer;
    }
    public void SetCurrentPlayer(int index)
    {
        _currentPlayer = _players[index];
    }
    
    public void MoveToNextPlayer()
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
    public IArena GetBoard()
    {
        return _arena;
    }
    public List<Tile> GetTileOnBoard()
    {
        return _tileOnBoard;
    }
    public List<Tile> GetTileVerticalOnBoard()
    {
        return _verticalTileOnBoard;
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
        foreach (var playerTile in _playersResource.Values)
        {
            foreach (var tile in playerTile)
            {
                if (tile.GetTileSideA() == validTile || tile.GetTileSideB() == validTile)
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
}
