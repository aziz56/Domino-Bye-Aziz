namespace Domino;


public class Arena : IArena
{
    private int _size;
    public int GetArenaSize()
    {
        return _size;
    }
    public bool SetArenaSize(int size)
    {
        if (size > 0)
        {
            _size = size;
            return true;
        }
        return false;
    }
}