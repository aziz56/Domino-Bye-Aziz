using System.Drawing;

namespace Domino;


public interface IArena
{
    int GetArenaSize();
    bool SetArenaSize(int size);
}
public interface IPlayer
{
    bool SetName(string? name);
    bool SetID(int id);
    string GetName();
    int GetID();
}
public interface ITile
{
    bool SetTileValue(int Side1, int Side2);
}