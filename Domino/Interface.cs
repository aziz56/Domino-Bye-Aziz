namespace Domino;


public interface IArena
{
    public int GetBoardSize();
    public bool SetBoardSize(int size);
}
public interface IPlayer
{
    bool SetName(string? name);
    bool SetID(int id);
    string? GetName();
    int GetID();
}
public interface ITile
{
    bool SetTileValue(int sideA, int sideB);
}