//Byte damage system
//DamagePackets

//BatchDamagePackets(params DamagePacket)

using System;
using UnityEngine;

public class DamageSystem
{
    public static void DamageEntity(DamageHandler entity, params DamagePacket[] packets)
    {
        for (int i = 0; i < packets.Length; i++)
            entity.OnRecieveDamagePacket(packets[i]);
    }

    public static void DamageEntities(DamageHandler[] entities, params DamagePacket[] packets)
    {
        for (int i = 0; i < entities.Length; i++)
            DamageEntity(entities[i], packets);
    }

}

[System.Serializable]
public struct DamagePacket
{
    public DamageType damageType;
    public float damageAmount;

    public DamagePacket(DamageType damageType, float damageAmount)
    {
        this.damageAmount = damageAmount;
        this.damageType = damageType;
    }

    public bool ContainsDamageType(DamageType damageType)
    {
        return this.damageType.HasFlag(damageType);
    }
}

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