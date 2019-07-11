using System;
using UnityEngine;

[System.Serializable]
public struct ClampedFloat
{
    [SerializeField]
    private float _value;
    
    public float Value
    {
        get => _value; set
        {
            _value = Mathf.Clamp(value, 0f, MaxValue);
        }
    }

    public float MaxValue;

    public static ClampedFloat operator +(ClampedFloat clampedFloat, float f)
    {
        clampedFloat.Value += f;
        return clampedFloat;
    }

    public static ClampedFloat operator -(ClampedFloat clampedFloat, float f)
    {
        clampedFloat.Value -= f;
        return clampedFloat;
    }

    public static ClampedFloat operator +(ClampedFloat c1, ClampedFloat c2)
    {
        c1.Value += c2.Value;
        return c1;
    }

    public static ClampedFloat operator -(ClampedFloat c1, ClampedFloat c2)
    {
        c1.Value -= c2.Value;
        return c1;
    }

    public static bool operator ==(ClampedFloat clampedFloat, float f)
    {
        return clampedFloat.Value == f;
    }

    public static bool operator !=(ClampedFloat clampedFloat, float f)
    {
        return clampedFloat.Value != f;
    }

      public static implicit operator float(ClampedFloat clampedFloat)
    {
        return clampedFloat.Value;
    }

}