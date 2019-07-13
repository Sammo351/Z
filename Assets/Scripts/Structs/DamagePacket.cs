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