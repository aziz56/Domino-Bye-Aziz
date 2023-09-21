namespace Domino;

public partial class GameController
{
    public bool MakeMove(Tile tile, int side)
    {
        List<Tile> currentPlayerTiles = _playerData[_currentPlayer];

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

        switch (side)
        {
            case 1:
                if (LeftValidSide(tile))
                {
                    SetTileOrientationAndAddValidSides(tile);
                    currentPlayerTiles.Remove(tile);
                    Turn();
                    return true;
                }
                break;

            case 2:
                if (RightValidSide(tile))
                {
                    SetTileOrientationAndAddValidSides(tile);
                    currentPlayerTiles.Remove(tile);
                    Turn();
                    return true;
                }
                break;

            case 3:
                if (side == 3 && _verticalTileOnArena.Count != 0 && BottomValidSide(tile))
                {
                    SetTileOrientationAndAddValidSides(tile, TileOrientation.horizontal, TileOrientation.vertical);
                    _verticalTileOnArena.Add(tile);
                    currentPlayerTiles.Remove(tile);
                    Turn();
                    return true;
                }
                break;

            case 4:
                if (side == 4 && _verticalTileOnArena.Count != 0 && TopValidSide(tile))
                {
                    SetTileOrientationAndAddValidSides(tile, TileOrientation.horizontal, TileOrientation.vertical);
                    _verticalTileOnArena.Add(tile);
                    currentPlayerTiles.Remove(tile);
                    Turn();
                    return true;
                }
                break;
        }

        return false;
    }

    private void SetTileOrientationAndAddValidSides(Tile tile, TileOrientation horizontalOrientation = TileOrientation.horizontal, TileOrientation verticalOrientation = TileOrientation.vertical)
    {
        if (tile.GetTileSide1() == tile.GetTileSide2())
        {
            tile.SetTileOrientation(verticalOrientation);
        }
        else
        {
            tile.SetTileOrientation(horizontalOrientation);
        }
        _validSideTiles.Add(tile.GetTileSide1());
        _validSideTiles.Add(tile.GetTileSide2());
    }

// private bool FirstValidMove(Tile tile)
// {
//     if (_tileOnArena.Count == 0)
//     {
//         if (tile.GetTileSide1() == tile.GetTileSide2())
//         {
//             tile.SetTileOrientation(TileOrientation.vertical);
//             _validSideTiles.Add(tile.GetTileSide2());
//             _validSideTiles.Add(tile.GetTileSide1());
//         }
//         else
//         {
//             tile.SetTileOrientation(TileOrientation.horizontal);
//             _validSideTiles.Add(tile.GetTileSide1());
//             _validSideTiles.Add(tile.GetTileSide2());
//         }
//         tile.SetTilePosition(_arena.GetArenaSize() / 2, _arena.GetArenaSize() / 2);
//         _tileOnArena.Add(tile);
//         return true;
//     }
//     return false;
// }
private bool FirstValidMove(Tile tile)
{
    if (_tileOnArena.Count == 0)
    {
        _validSideTiles.Add(tile.GetTileSide1());
        _validSideTiles.Add(tile.GetTileSide2());
        tile.SetTilePosition(_arena.GetArenaSize() / 2, _arena.GetArenaSize() / 2);
        _tileOnArena.Add(tile);
        return true;
    }
    return false;
}

private bool LeftValidSide(Tile thisTile)
{
    int leftTilePosX = _tileOnArena[0].GetTilePosition().GetPosX();
    int leftTilePosY = _tileOnArena[0].GetTilePosition().GetPosY();

    if (thisTile.GetTileSide1() == _validSideTiles[0])
    {
        if (leftTilePosX > 1)
        {
            thisTile.SetTilePosition(leftTilePosX - 1, leftTilePosY);
        }
        else if (leftTilePosX == 1)
        {
            thisTile.SetTilePosition(leftTilePosX, leftTilePosY + 1);
        }
        _validSideTiles[0] = thisTile.GetTileSide2();
        thisTile.FlipTiles();
        _tileOnArena.Insert(0, thisTile);
        return true;
    }
    else if (thisTile.GetTileSide2() == _validSideTiles[0])
    {
        if (leftTilePosX > 1)
        {
            thisTile.SetTilePosition(leftTilePosX - 1, leftTilePosY);
        }
        else if (leftTilePosX == 1)
        {
            thisTile.SetTilePosition(leftTilePosX, leftTilePosY + 1);
        }
        _validSideTiles[0] = thisTile.GetTileSide1();
        _tileOnArena.Insert(0, thisTile);
        return true;
    }
    return false;
}
private bool RightValidSide(Tile thisTile)
{
    int rightTilePosX = _tileOnArena[^1].GetTilePosition().GetPosX();
    int rightTilePosY = _tileOnArena[^1].GetTilePosition().GetPosY();

    if (thisTile.GetTileSide1() == _validSideTiles[1])
    {
        if (rightTilePosX < _arena.GetArenaSize() - 1)
        {
            thisTile.SetTilePosition(rightTilePosX + 1, rightTilePosY);
        }
        else if (rightTilePosX == _arena.GetArenaSize() - 1)
        {
            thisTile.SetTilePosition(rightTilePosX, rightTilePosY - 1);
        }
        _validSideTiles[1] = thisTile.GetTileSide2();
        _tileOnArena.Add(thisTile);
        return true;
    }
    else if (thisTile.GetTileSide2() == _validSideTiles[1])
    {
        if (rightTilePosX < _arena.GetArenaSize() - 1)
        {
            thisTile.SetTilePosition(rightTilePosX + 1, rightTilePosY);
        }
        else if (rightTilePosX == _arena.GetArenaSize() - 1)
        {
            thisTile.SetTilePosition(rightTilePosX, rightTilePosY - 1);
        }
        _validSideTiles[1] = thisTile.GetTileSide1();
        thisTile.FlipTiles();
        _tileOnArena.Add(thisTile);
        return true;
    }
    return false;
}
private bool ValidateTopAndButtomSide()
{
    if (_verticalTileOnArena.Count == 0 && _tileOnArena.Count >= 0)
    {
        foreach (var tile in _tileOnArena)
        {
            if (tile.GetTileOrientation() == TileOrientation.vertical)
            {
                if (tile != _tileOnArena[0] && tile != _tileOnArena[_tileOnArena.Count - 1])
                {
                    int validTopSide = tile.GetTileSide1();
                    _validSideTiles.Add(validTopSide);
                    int validButtomSide = tile.GetTileSide2();
                    _validSideTiles.Add(validButtomSide);
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

    if (thisTile.GetTileSide1() == _validSideTiles[3])
    {
        thisTile.SetTilePosition(TopTilePosX, TopTilePosY - 1);
        _validSideTiles[3] = thisTile.GetTileSide2();
        // thisTile.FlipTiles();
        _verticalTileOnArena.Add(thisTile);
        return true;
    }
    else if (thisTile.GetTileSide2() == _validSideTiles[3]) // Corrected condition here
    {
        thisTile.SetTilePosition(TopTilePosX, TopTilePosY - 1);
        _validSideTiles[3] = thisTile.GetTileSide2();
        _verticalTileOnArena.Add(thisTile);
        return true;
    }
    return false;
}

private bool BottomValidSide(Tile thisTile)
{
    int buttomTilePosX = _verticalTileOnArena[0].GetTilePosition().GetPosX();
    int buttomTilePosY = _verticalTileOnArena[0].GetTilePosition().GetPosY();

    if (thisTile.GetTileSide1() == _validSideTiles[2])
    {
        thisTile.SetTilePosition(buttomTilePosX, buttomTilePosY + 1);
        _validSideTiles[2] = thisTile.GetTileSide2();
        // thisTile.FlipTiles();
        _verticalTileOnArena.Insert(0, thisTile);
        return true;
    }
    else if (thisTile.GetTileSide2() == _validSideTiles[2]) // Correct
    {
        thisTile.SetTilePosition(buttomTilePosX, buttomTilePosY + 1);
        _validSideTiles[2] = thisTile.GetTileSide2();
        _verticalTileOnArena.Insert(0, thisTile);
        return true;
    }
    return false;
}}

        
// thisTile.FlipTiles(); 
// thisTile.FlipTiles();