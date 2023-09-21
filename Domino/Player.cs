using System.Diagnostics.Contracts;
using System.Dynamic;

namespace Domino;

public class Player : IPlayer
{
    private int _id;
    private string? _name;

    public bool SetName(string? name)
    {
        if (name == null)
        {
            return false;
        }
        _name = name;
        return true;
    }
    public bool SetID(int id)
    {
        _id = id;
        return true;
    }
    public string GetName()
    {
        if (_name != null)
        {
            return _name;
        }
        else
        {
            throw new Exception("Nama Belum di Set");
        }
    }
    public int GetID()
    {
        if (_id != null)
        {
            return _id;
        }
        else
        {
            throw new Exception ("ID Belum di Set");
        }
    } 

}



