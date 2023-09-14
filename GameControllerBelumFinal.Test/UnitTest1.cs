namespace GameControllerBelumFinal.Test;
using Domino;
public class Tests
{
    private GameController? gameController;
    [SetUp]
    public void Setup()
    {
        gameController = new();
    }

    [Test]
    public void AddPlayer()
    {
     IPlayer player = new Player();
     player.SetID(12);
     player.SetName("Aziz");

    // Console.WriteLine(player.GetID());
    // Console.WriteLine(player.GetName());
    string expectedName = "Aaziz";
    int expectedID  = 2;

    string actualName = player.GetName();
    int actualID = player.GetID();
    Assert.AreEqual(expectedName,actualName);
    Assert.AreEqual(expectedID,actualID);
    }
}