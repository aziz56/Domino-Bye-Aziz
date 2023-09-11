using System;
using System.Collections.Generic;

namespace Domino
{
    public partial class GameController
    {
        private Dictionary<IPlayer, List<Tile>> _playerData;
        private List<IPlayer> _players;
        private Deck _deck;
        private IArena _arena;
        private IPlayer? _currentPlayer;
        private List<Tile> _tileOnArena;
        private List<int> _validSideTile;
        private List<Tile> _verticalTileOnArena;
        private GameMode _gameMode;
        public GameController()
        {
            _players = new List<IPlayer>();
            _playerData = new Dictionary<IPlayer, List<Tile>>();
            _arena = new Arena();
            _deck = new Deck();
            _currentPlayer = null;
            _validSideTile = new List<int>();
            _tileOnArena = new List<Tile>();
            _verticalTileOnArena = new List<Tile>();
            _gameMode = GameMode.drawmode;
        }
        public GameController(IPlayer player, List<Tile> tile)
        {
            _players = new List<IPlayer>();
            _playerData = new Dictionary<IPlayer, List<Tile>>();
            _playerData.Add(player, tile);
            _arena = new Arena();
            _deck = new Deck();
            _validSideTile = new List<int>();
            _tileOnArena = new List<Tile>();
            _verticalTileOnArena = new List<Tile>();
        }

        public bool AddPlayer(IPlayer player)
        {
            if (player != null && !_players.Contains(player))
            {
                _players.Add(player);
                _playerData.Add(player, new List<Tile>());
                return true;
            }
            return false;
        }

        public bool AddDeck(Deck deck)
        {
            if (deck != null && _deck == null)
            {
                _deck = deck;
                return true;
            }
            return false;
        }

        public bool AddArena(IArena arena)
        {
            if (arena != null && _arena == null)
            {
                _arena = arena;
                return true;
            }
            return false;
        }

        public IPlayer? GetCurrentPlayer()
        {
        return _currentPlayer;
         }
        public void SetCurrentPlayer(int index)
        {
            if (index >= 0 && index < _players.Count)
            {
                _currentPlayer = _players[index];
            }
        }
        public bool CheckTileAvailable()
        {
            if (_deck.GetTilesDeck()?.Count != 0)
            {
                return true;
            }
            return false;
        }
        public void Turn()
        {
            if (_currentPlayer != null)
            {
                int currentPlayerIndex = _players.IndexOf(_currentPlayer);
                if (currentPlayerIndex >= 0 && currentPlayerIndex < _players.Count - 1)
                {
                    _currentPlayer = _players[currentPlayerIndex + 1];
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

        public List<Tile> GetTileOnArena()
        {
            return _tileOnArena;
        }
         public List<Tile> GetTileVerticalOnArena()
    {
        return _verticalTileOnArena;
    }
        public List<Tile> GetPlayerTiles(IPlayer player)
        {
        return _playerData[player];
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
            if (_deck.GetTileData() != null && _playerData.TryGetValue(player, out List<Tile>playerTiles))
            {
                for (int i = 0; i < count; i++)
                {
                    List<int>? tileData = _deck.GetTileData();
                    if (tileData != null)
                    {
                        int a = tileData[0];
                        int b = tileData[1];
                        playerTiles.Add(new Tile(a, b));
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

        public bool GameEndWithZeroTile()
        {
            foreach (var playerTiles in _playerData.Values)
            {
                if (playerTiles.Count == 0)
                {
                    return true;
                }
            }
            return false;
        }

        private bool GameEndWithNoSameTiles(int validTile)
        {
            foreach (var playerTiles in _playerData.Values)
            {
                foreach (var tile in playerTiles)
                {
                    if (tile.GetTileSide1() == validTile || tile.GetTileSide2() == validTile)
                    {
                        return false; // At least one player has a tile with the valid side
                    }
                }
            }

            return true; // No player has a tile with the valid side
        }

        public bool ValidMove(IPlayer player)
        {
            foreach (var thisTile in _playerData[player])
            {
                if (_tileOnArena.Count == 0)
                {
                    return true;
                }
                else if (thisTile.GetTileSide1() == _validSideTile[0] || thisTile.GetTileSide2() == _validSideTile[0])
                {
                    return true;
                }
                else if (thisTile.GetTileSide1() == _validSideTile[1] || thisTile.GetTileSide2() == _validSideTile[1])
                {
                    return true;
                }
                else if (_verticalTileOnArena.Count != 0)
                {
                    if (thisTile.GetTileSide1() == _validSideTile[2] || thisTile.GetTileSide2() == _validSideTile[2])
                    {
                        return true;
                    }
                    if (thisTile.GetTileSide1() == _validSideTile[3] || thisTile.GetTileSide2() == _validSideTile[3])
                    {
                        return true;
                    }
                }
            }

            return false; // No valid move found
        }
    }
}