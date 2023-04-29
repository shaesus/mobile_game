using System;
using System.Collections.Generic;
using UnityEngine;

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
        {
            _buffs.Add(buff);
            buff.EnableBuff();

            Debug.Log($"Buff count: {_buffs.Count}");
        }

        BuffAdded?.Invoke();
    }

    public void RemoveBuff(Buff buff)
    {
        var buffIndex = _buffs.IndexOf(buff);
        if (buffIndex > -1)
        {
            _buffs[buffIndex].DisableBuff();
            _buffs.RemoveAt(buffIndex);

            Debug.Log($"Buff count: {_buffs.Count}");
        }

        BuffRemoved?.Invoke();
    }
}
