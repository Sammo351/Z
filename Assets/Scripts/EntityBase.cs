using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntityBase : MonoBehaviour
{
    [Min(0)]
    public float Stamina;
    public ClampedFloat Health;

    public UnityEvent<float> OnHealthChanged;
    public UnityEvent<float> OnStaminaChanged;

}
