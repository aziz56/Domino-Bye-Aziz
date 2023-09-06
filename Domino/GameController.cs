namespace Domino;

public class GameController
{
    private Dictionary<IPlayer,ITile>_playerData;
    private List<IPlayer>_players;
    private List<ITile>_tiles;
    private Deck _deck;
    private IArena _arena;


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

}
