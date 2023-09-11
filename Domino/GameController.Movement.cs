namespace Domino;

public partial class GameController
{

    public bool MakeMove(Tile tile, int side)
    {
        List<Tile>currentPlayerTiles = _playerData[_currentPlayer];
        if (_verticalTileOnArena.Count == 0)
        {
            ValidateTopAndButtomSide();
        }
        if (FirstValidMove(tile))
        {
            currentPlayerTiles.Remove(tile);
            Turn();
            return true;
        }
        //logic for nextmove
        else if (!FirstValidMove(tile) && _tileOnArena != null)
        {
            if (side == 1)
            {
                if (LeftValidSide(tile))
                {
                    if (tile.GetTileSide1() == tile.GetTileSide2())
                    {
                        tile.SetTileOrientation(TileOrientation.vertical);
                    }
                    else if (tile.GetTileSide1() != tile.GetTileSide2())
                    {
                        tile.SetTileOrientation(TileOrientation.horizontal);
                    }
                    currentPlayerTiles.Remove(tile);
                    Turn();
                    return true;
                }
                return false;
            }
            else if (side == 2)
            {
                if (RightValidSide(tile))
                {
                    if (tile.GetTileSide1() == tile.GetTileSide2())
                    {
                        tile.SetTileOrientation(TileOrientation.vertical);
                    }
                    else if (tile.GetTileSide1() != tile.GetTileSide2())
                    {
                        tile.SetTileOrientation(TileOrientation.horizontal);
                    }
                    currentPlayerTiles.Remove(tile);
                    Turn();
                    return true;
                }
                return false;
            }
            else if (side == 3 && _verticalTileOnArena.Count != 0)
            {
                if (BottomValidSide(tile))
                {
                    if (tile.GetTileSide1() == tile.GetTileSide1())
                    {
                        tile.SetTileOrientation(TileOrientation.horizontal);
                    }
                    else if (tile.GetTileSide1() != tile.GetTileSide2())
                    {
                        tile.SetTileOrientation(TileOrientation.vertical);
                    }
                    currentPlayerTiles.Remove(tile);
                    Turn();
                    return true;
                }
                return false;
            }
            else if (side == 4 && _verticalTileOnArena.Count != 0)
            {
                if (TopValidSide(tile))
                {
                    if (tile.GetTileSide1() == tile.GetTileSide2())
                    {
                        tile.SetTileOrientation(TileOrientation.horizontal);
                    }
                    else if (tile.GetTileSide2() != tile.GetTileSide2())
                    {
                        tile.SetTileOrientation(TileOrientation.vertical);
                    }
                    currentPlayerTiles.Remove(tile);
                    Turn();
                    return true;
                }
                return false;
            }
        }
        return false;
    }
    private bool FirstValidMove(Tile tile)
    {
        if (_tileOnArena.Count == 0)
        {
            if (tile.GetTileSide1() == tile.GetTileSide2())
            {
                tile.SetTileOrientation(TileOrientation.vertical);
                _validSideTile.Add(tile.GetTileSide2());
                _validSideTile.Add(tile.GetTileSide2());
            }
            else
            {
                tile.SetTileOrientation(TileOrientation.horizontal);
                _validSideTile.Add(tile.GetTileSide1());
                _validSideTile.Add(tile.GetTileSide2());
            }
            tile.SetTilePosition(_arena.GetArenaSize() / 2, _arena.GetArenaSize() / 2);
            _tileOnArena.Add(tile);
            return true;
        }
        return false;
    }

    /// <summary>
    /// this 4 method is to set tile on left, right, top and left of dominoes game board
    /// validating with _validSIdeTile index 0, 1, 2 , 3
    /// if this tile side A or B have same number with every _validSIdeTile
    /// </summary>
    /// <param name="thisTile"></param>
    /// <returns>true if have same number</returns> <summary>
    /// 
    /// </summary>
    /// <param name="thisTile"></param>
    /// <returns>false if have not same number</returns>
    private bool LeftValidSide(Tile thisTile)
    {
        int leftTilePosX = _tileOnArena[0].GetTilePosition().GetPosX();
        int leftTilePosY = _tileOnArena[0].GetTilePosition().GetPosY();

        if (thisTile.GetTileSide1() == _validSideTile[0])
        {
            if (leftTilePosX > 1)
            {
                thisTile.SetTilePosition(leftTilePosX - 1, leftTilePosY);
            }
            else if (leftTilePosX == 1)
            {
                thisTile.SetTilePosition(leftTilePosX, leftTilePosY + 1);
            }
            _validSideTile[0] = thisTile.GetTileSide2();
            thisTile.FlipTiles();
            _tileOnArena.Insert(0, thisTile);
            return true;
        }
        else if (thisTile.GetTileSide2() == _validSideTile[0])
        {
            if (leftTilePosX > 1)
            {
                thisTile.SetTilePosition(leftTilePosX - 1, leftTilePosY);
            }
            else if (leftTilePosX == 1)
            {
                thisTile.SetTilePosition(leftTilePosX, leftTilePosY + 1);
            }
            _validSideTile[0] = thisTile.GetTileSide1();
            _tileOnArena.Insert(0, thisTile);
            return true;
        }
        return false;
    }
    private bool RightValidSide(Tile thisTile)
    {
        int rightTilePosX = _tileOnArena[^1].GetTilePosition().GetPosX();
        int rightTilePosY = _tileOnArena[^1].GetTilePosition().GetPosY();

        if (thisTile.GetTileSide1() == _validSideTile[1])
        {
            if (rightTilePosX < _arena.GetArenaSize() - 1)
            {
                thisTile.SetTilePosition(rightTilePosX + 1, rightTilePosY);
            }
            else if (rightTilePosX == _arena.GetArenaSize() - 1)
            {
                thisTile.SetTilePosition(rightTilePosX, rightTilePosY - 1);
            }
            _validSideTile[1] = thisTile.GetTileSide2();
            _tileOnArena.Add(thisTile);
            return true;
        }
        else if (thisTile.GetTileSide2() == _validSideTile[1])
        {
            if (rightTilePosX < _arena.GetArenaSize() - 1)
            {
                thisTile.SetTilePosition(rightTilePosX + 1, rightTilePosY);
            }
            else if (rightTilePosX == _arena.GetArenaSize() - 1)
            {
                thisTile.SetTilePosition(rightTilePosX, rightTilePosY - 1);
            }
            _validSideTile[1] = thisTile.GetTileSide1();
            thisTile.FlipTiles();
            _tileOnArena.Add(thisTile);
            return true;
        }
        return false;
    }
    private bool ValidateTopAndButtomSide()
    {
        if (_verticalTileOnArena.Count == 0 && _tileOnArena.Count >= 3)
        {
            foreach (var tile in _tileOnArena)
            {
                if (tile.GetTileOrientation() == TileOrientation.vertical)
                {
                    if (tile != _tileOnArena[0] && tile != _tileOnArena[_tileOnArena.Count - 1])
                    {
                        int validTopSide = tile.GetTileSide1();
                        _validSideTile.Add(validTopSide);
                        int validButtomSide = tile.GetTileSide2();
                        _validSideTile.Add(validButtomSide);
                        _verticalTileOnArena.Add(tile);
                        _tileOnArena.Remove(tile);
                        return true;
                    }
                }
            }
        }
        return false;
    }
    private bool TopValidSide(Tile thisTile)
    {
        int TopTilePosX = _verticalTileOnArena[0].GetTilePosition().GetPosX();
        int TopTilePosY = _verticalTileOnArena[^1].GetTilePosition().GetPosY();

        if (thisTile.GetTileSide1() == _validSideTile[3])
        {
            thisTile.SetTilePosition(TopTilePosX, TopTilePosY - 1);
            _validSideTile[3] = thisTile.GetTileSide2();
           
            _verticalTileOnArena.Add(thisTile);
            return true;
        }
        else if (thisTile.GetTileSide1() == _validSideTile[3])
        {
            thisTile.SetTilePosition(TopTilePosX, TopTilePosY - 1);
            _validSideTile[3] = thisTile.GetTileSide1();
            _verticalTileOnArena.Add(thisTile);
            return true;
        }
        return false;
    }
    private bool BottomValidSide(Tile thisTile)
    {
        int buttomTilePosX = _verticalTileOnArena[0].GetTilePosition().GetPosX();
        int buttomTilePosY = _verticalTileOnArena[0].GetTilePosition().GetPosY();
        if (thisTile.GetTileSide1() == _validSideTile[2])
        {
            thisTile.SetTilePosition(buttomTilePosX, buttomTilePosY + 1);
            _validSideTile[2] = thisTile.GetTileSide2();
            _verticalTileOnArena.Insert(0, thisTile);
            return true;
        }
        else if (thisTile.GetTileSide1() == _validSideTile[2])
        {
            thisTile.SetTilePosition(buttomTilePosX, buttomTilePosY + 1);
            _validSideTile[2] = thisTile.GetTileSide1();
            
            _verticalTileOnArena.Insert(0, thisTile);
            return true;
        }
        return false;
    }

}
        
    // thisTile.FlipTiles();
     // thisTile.FlipTiles();