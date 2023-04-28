using System;
using System.Collections.Generic;

public class BuffContainer
{
    public event Action BuffAdded;
    public event Action BuffRemoved;

    private List<Buff> _buffs;

    public BuffContainer()
    {
        _buffs = new List<Buff>();
    }

    public void AddBuff(Buff buff)
    {
        if (buff != null)
            _buffs.Add(buff);

        BuffAdded?.Invoke();
    }

    public void RemoveBuff(Buff buff)
    {
        if (_buffs.Contains(buff))
            _buffs.Remove(buff);

        BuffRemoved?.Invoke();
    }
}
