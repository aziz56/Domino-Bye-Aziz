using NUnit.Framework;

namespace Domino.Test;

public class GameControllerTest
{
    private GameController _gamecontroller;
    [SetUp]
    public void Setup()
    {
        _gamecontroller = new GameController();
    }

[Test]
    public void AddPlayer()
    {
     IPlayer player = new Player();
     player.SetID(12);
     player.SetName("Aziz");

    // Console.WriteLine(player.GetID());
    // Console.WriteLine(player.GetName());
    
    //Act
    string expectedName = "Aziz";
    int expectedID  = 12;

    string actualName = player.GetName();
    int actualID = player.GetID();
    //assert
    Assert.AreEqual(expectedName,actualName);
    Assert.AreEqual(expectedID,actualID);
    }

[Test]

public void FirstValidMove()
{
    //arrange
    IPlayer player1 = new Player();
    _gamecontroller.AddPlayer(player1);
    Tile tile = new Tile(1,1);
    _gamecontroller.GetPlayerTiles(player1).Add(tile);
    _gamecontroller.SetCurrentPlayer(0);
    //act
    _gamecontroller.MakeMove(tile,6);
    List<Tile> listTile = _gamecontroller.GetTileOnBoard();

    Tile firstTile = listTile[0];
    TileOrientation expect = TileOrientation.vertical;
    TileOrientation actual = firstTile.GetTileOrientation();
    //assert
    Assert.AreEqual(expect,actual);
}}



