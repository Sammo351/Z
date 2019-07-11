using System;
using UnityEngine;

[System.Serializable]
public struct ClampedInt
{
    [SerializeField]
    private int _value;
    public int Value
    {
        get => _value; set
        {
            _value = Mathf.Clamp(value, 0, MaxValue);
        }
    }

    public int MaxValue;

    public static ClampedInt operator +(ClampedInt clampedInt, int i)
    {
        clampedInt.Value += i;
        return clampedInt;
    }

    public static ClampedInt operator -(ClampedInt clampedInt, int i)
    {
        clampedInt.Value -= i;
        return clampedInt;
    }

    public static ClampedInt operator +(ClampedInt c1, ClampedInt c2)
    {
        c1.Value += c2.Value;
        return c1;
    }

    public static ClampedInt operator -(ClampedInt c1, ClampedInt c2)
    {
        c1.Value -= c2.Value;
        return c1;
    }

    public static bool operator ==(ClampedInt clampedInt, int i)
    {
        return clampedInt.Value == i;
    }

    public static bool operator !=(ClampedInt clampedInt, int i)
    {
        return clampedInt.Value != i;
    }

    public static implicit operator int(ClampedInt clampedInt)
    {
        return clampedInt.Value;
    }
}