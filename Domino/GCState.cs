namespace Domino;
public delegate void GameEndedEventHandler(object sender, EventArgs e);
public partial class GameController
{
    public event GameEndedEventHandler? gameEnded;
    public bool IsEnded()
    {
                if (_arena == null || _players == null || _playerData == null)
        {
            return false;
        }
        if (GameEndWithZeroTile())
        {

            gameEnded?.Invoke(this, EventArgs.Empty);
            return true;
        }
        if (_gameMode == GameMode.blockmode && _validSideTile.Count >= 2)
        {
            if (GameEndWithNoSameTiles(_validSideTile[0]) && GameEndWithNoSameTiles(_validSideTile[1]))
            {
                if (_verticalTileOnArena.Count != 0)
                {
                    if (GameEndWithNoSameTiles(_validSideTile[2]) && GameEndWithNoSameTiles(_validSideTile[3]))
                    {
                        return true;
                    }
                }
                else
                {
                    gameEnded?.Invoke(this, EventArgs.Empty);
                    return true;
                }
            }
        }
        if (_deck.GetTilesDeck()?.Count == 0 && _validSideTile.Count >= 2)
        {
            if (GameEndWithNoSameTiles(_validSideTile[0]) && GameEndWithNoSameTiles(_validSideTile[1]))
            {
                if (_verticalTileOnArena.Count != 0)
                {
             
                    if (GameEndWithNoSameTiles(_validSideTile[2]) && GameEndWithNoSameTiles(_validSideTile[3]))
                    {
                        gameEnded?.Invoke(this, EventArgs.Empty);
                        return true;
                    }
                }
                else
                {
               
                    gameEnded?.Invoke(this, EventArgs.Empty);
                    return true;
                }
            }
        }
        return false;
    }
    public List<KeyValuePair<IPlayer, int>> GetLeaderBoard()
    {
        List<KeyValuePair<IPlayer, int>> leaderBoard = new();

        foreach (var player in _playerData.Keys)
        {
            int tileCount = PlayerTileCount(player);
            leaderBoard.Add(new KeyValuePair<IPlayer, int>(player, tileCount));
        }
        leaderBoard.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
        return leaderBoard;
    }
    private int PlayerTileCount(IPlayer player)
    {
        if (_playerData.TryGetValue(player, out List<Tile>? playerTiles))
        {
            int count = playerTiles.Sum(tile => tile.GetTileSide1() + tile.GetTileSide2());
            return count;
        }
        return 0;
    }
}

