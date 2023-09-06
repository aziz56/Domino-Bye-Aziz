namespace Domino;


public class Arena : IArena
{
    private int _size;
    public int GetBoardSize()
    {
        return _size;
    }
    public bool SetBoardSize(int size)
    {
        if (size > 0)
        {
            _size = size;
            return true;
        }
        return false;
    }
}