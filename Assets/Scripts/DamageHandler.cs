using System;
using UnityEngine;


public class DamageHandler : MonoBehaviour
{
    public DamageAffect[] damageAffects;

    internal void OnRecieveDamagePacket(DamagePacket damagePacket)
    {
        for (int i = 0; i < damageAffects.Length; i++)
        {
            if (damagePacket.ContainsDamageType(damageAffects[i].damageType))
            {
                float f = GetMultiplierFromAffectType(damageAffects[i].damageAffectType);
                float totalDamage = damagePacket.damageAmount * f;
                Debug.Log($"Dealing {totalDamage} damage from {damagePacket.damageType}");
            }
        }
    }

    public float GetMultiplierFromAffectType(DamageAffectType damageAffectType)
    {
        switch (damageAffectType)
        {
            case DamageAffectType.Default:      return 1;
            case DamageAffectType.Immune:       return 0;
            case DamageAffectType.Resistant:    return 0.5f;
            case DamageAffectType.Weakness:     return 1.5f;
            case DamageAffectType.Vunerable:    return 2f;
            default:                            return 1f;
        }


    }
}

[System.Serializable]
public struct DamageAffect
{
    public DamageType damageType;
    public DamageAffectType damageAffectType;
}

[System.Serializable]
public enum DamageAffectType
{
    Immune,
    Resistant,
    Default,
    Weakness,
    Vunerable
}