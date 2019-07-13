using System;

[Flags]
[System.Serializable]
public enum DamageType
{
    Default = 1 << 0,
    Piercing = 1 << 1,
    Bludgeoning = 1 << 2,
    Slashing = 1 << 3,
    Force = 1 << 4,
    Fire = 1 << 5,
    Acid = 1 << 6,
    Posion = 1 << 7,
    Necrotic = 1 << 8
}