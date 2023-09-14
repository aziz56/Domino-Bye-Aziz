// using System.Reflection.Metadata.Ecma335;

// //namespace Domino;

// public partial class GameController
// {
// public bool ValidMove(IPlayer player)
// {
// if (_tileOnArena.Count == 0)
//     {
//     return true;
//     }

//     int LeftSide = _validSideTiles[0];
//     int RightSide = _validSideTiles[1];
//     int topSide = _verticalTileOnArena.Count > 0 ? _validSideTiles[3] : -1;
//     int BottomSide = _verticalTileOnArena.Count > 0 ? _validSideTiles[2]:-1;
//     foreach (var tile in _playerData[player])
//     {
//             int side1 = tile.GetTileSide1();
//             int side2 = tile.GetTileSide2();
//             if (side1 == LeftSide || side1 == RightSide || side1 == topSide || side1 == BottomSide ||
//                 side2 == LeftSide || side2 == RightSide || side2 == topSide || side2 == BottomSide)
//         {
//              return true;
//         }
//     }
//     return false;
//     }
//     public bool 
// }
