using System;
using UnityEngine;
using UnityEngine.Events;

public class DamageHandler : MonoBehaviour
{
    public DamageAffect[] damageAffects;
    public UnityEvent<DamagePacket> OnDamaged;

    private EntityBase _entity;
    void Awake() { _entity = GetComponent<EntityBase>(); }

    internal void OnRecieveDamagePacket(DamagePacket damagePacket)
    {
        for (int i = 0; i < damageAffects.Length; i++) // Scan through all damage types, and handle damage accordingly to DamageAffect values
        {
            if (damagePacket.ContainsDamageType(damageAffects[i].damageType))
            {
                float f = GetMultiplierFromAffectType(damageAffects[i].damageAffectType);
                damagePacket.damageAmount *= f;
                break;
            }
        }

        if (OnDamaged != null)
            OnDamaged.Invoke(damagePacket);

        if (_entity == null)
            return;

        _entity.ModifyHealth(-damagePacket.damageAmount);
    }

    public float GetMultiplierFromAffectType(DamageAffectType damageAffectType)
    {
        switch (damageAffectType)
        {
            case DamageAffectType.Default: return 1;
            case DamageAffectType.Immune: return 0;
            case DamageAffectType.Resistant: return 0.5f;
            case DamageAffectType.Weakness: return 1.5f;
            case DamageAffectType.Vunerable: return 2f;
            default: return 1f;
        }
    }
}

