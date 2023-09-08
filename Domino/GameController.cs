using System;
using System.Collections.Generic;

namespace Domino
{
    public class GameController
    {
        private Dictionary<IPlayer, List<Tile>> _playerData;
        private List<IPlayer> _players;
        private Deck _deck;
        private IArena _arena;
        private IPlayer? _currentPlayer;
        private List<Tile> _tileOnBoard;

        public GameController()
        {
            _players = new List<IPlayer>();
            _playerData = new Dictionary<IPlayer, List<Tile>>();
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

        public List<Tile> GetTileOnBoard()
        {
            return _tileOnBoard;
        }



        public bool GenerateTiles(IPlayer player, int count)
        {
            if (_deck.GetTileData() != null && _playerData.TryGetValue(player, out List<Tile> playerTiles))
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
    }
}