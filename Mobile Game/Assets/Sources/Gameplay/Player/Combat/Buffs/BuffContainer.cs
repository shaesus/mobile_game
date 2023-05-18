using System;
using System.Collections.Generic;
using UnityEngine;

public class BuffContainer
{
    public event Action BuffAdded;
    public event Action BuffRemoved;

    private List<Buff> _buffs;

    private int _capacity;

    public BuffContainer()
    {
        _capacity = 6;

        _buffs = new List<Buff>(_capacity);
    }

    public void AddBuff(Buff buff)
    {
        if (buff == null)
            return;

        if (_buffs.Count < _capacity)
        {
            _buffs.Add(buff);
            buff.EnableBuff();
        }
        else
        {
            //Buff choice menu
        }

        Debug.Log($"Buff count: {_buffs.Count}");

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

    public void UpdateBuffs()
    {
        foreach (var buff in _buffs)
        {
            buff.UpdateBuff();
        }
    }
}
