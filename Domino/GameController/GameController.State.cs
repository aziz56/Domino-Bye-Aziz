namespace Domino;
public delegate void GameEnded(object sender, EventArgs e);
public partial class GameController
{
    public event GameEnded? gameEnded;
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
        if (_gameMode == GameMode.blockmode && _validSideTiles.Count >= 2)
        {
            if (GameEndWithNoSameTiles(_validSideTiles[0]) && GameEndWithNoSameTiles(_validSideTiles[1]))
            {
                if (_verticalTileOnArena.Count != 0)
                {
                    if (GameEndWithNoSameTiles(_validSideTiles[2]) && GameEndWithNoSameTiles(_validSideTiles[3]))
                    {
                        return true;
                    }
                }
                else
                {
                    logger.Info(" block mode : game end with zerotile");
                    gameEnded?.Invoke(this, EventArgs.Empty);
                    return true;
                }
            }
        }
        if (_deck.GetTilesDeck()?.Count == 0 && _validSideTiles.Count >= 2)
        {
            if (GameEndWithNoSameTiles(_validSideTiles[0]) && GameEndWithNoSameTiles(_validSideTiles[1]))
            {
                if (_verticalTileOnArena.Count != 0)
                {
             
                    if (GameEndWithNoSameTiles(_validSideTiles[2]) && GameEndWithNoSameTiles(_validSideTiles[3]))
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
            int count = playerTiles.Count;
            return count;
        }
        return 0;
    }
}

