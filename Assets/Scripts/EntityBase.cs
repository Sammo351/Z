using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(DamageHandler))]
public class EntityBase : MonoBehaviour
{
    [Min(0)]
    public float Stamina;
    public ClampedFloat Health;

    public VitalEvent OnHealthChanged;
    public VitalEvent OnStaminaChanged;

    public void ModifyHealth(float m)
    {
        Health += m;
        if (OnHealthChanged != null)
            OnHealthChanged.Invoke(Health);
    }

    public bool IsDead() => Health <= 0;
}

[System.Serializable]
public class VitalEvent : UnityEvent<float> { }