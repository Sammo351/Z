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

