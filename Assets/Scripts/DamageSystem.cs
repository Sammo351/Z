using System;

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

    public static void DamageEntity(DamageHandler entity, float damageAmount, DamageType damageType)
    {
        DamageEntity(entity, new DamagePacket(damageType, damageAmount));
    }

    public static void DamageEntity(EntityBase entity, params DamagePacket[] packets)
    {
        DamageEntity(entity.GetComponent<DamageHandler>(), packets);
    }

    public static void DamageEntity(EntityBase entity, float damageAmount, DamageType damageType)
    {
        DamageEntity(entity.GetComponent<DamageHandler>(), damageAmount, damageType);
    }

    public static void DamageEntities(EntityBase[] entities, params DamagePacket[] packets)
    {
        for (int i = 0; i < entities.Length; i++)
            DamageEntity(entities[i], packets);
    }


    public static void DamageEntities(DamageHandler[] entities, float damage, DamageType damageType)
    {
        for (int i = 0; i < entities.Length; i++)
            DamageEntity(entities[i], damage, damageType);
    }
}


