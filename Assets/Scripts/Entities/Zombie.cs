using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Zombie : AICharacterBase
{

    [Header("Target Settings")]
    public LayerMask targetLayerMask;
    public EntityBase BestTarget;

    public enum ZombieState
    {
        Idle,
        Walking,
        Chasing
    }

    public ZombieState currentState = ZombieState.Idle;

    internal override void HandleStateMachine()
    {
        Debug.Log("Running");
        switch (currentState)
        {
            case ZombieState.Idle:
                Idle();
                break;
            case ZombieState.Walking:
                Walking();
                break;
            case ZombieState.Chasing:
                Chasing();
                break;
        }
    }

    void Idle()
    {
        EntityBase[] entities = GetEntitiesInRange(sightCone.Range, targetLayerMask);
        entities = entities.Where(a => CanSeeTarget(a.transform) && a != ((EntityBase)this)).ToArray();
        BestTarget = GetBestSuitedTarget(entities);

        if (BestTarget)
            _navMeshAgent.SetDestination(BestTarget.transform.position);

        if (_navMeshAgent.remainingDistance <= 1f)
        {
            if (Time.time - lastAttackTime > 1f)
            {
                DamageSystem.DamageEntity(BestTarget, 3f, DamageType.Piercing);
                lastAttackTime = Time.time;
            }
        }
    }

    float lastAttackTime = 0f;

    void Walking()
    {

    }

    void Chasing()
    {

    }
}
