using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Survivor : AICharacterBase
{
    void Start()
    {
        OnHealthChanged.AddListener(HealthChanged);
    }

    void HealthChanged(float h)
    {
        if (IsDead())
            Destroy(this.gameObject);
    }
}
