using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(RigidbodyCharacter))]
public class AICharacterBase : EntityBase
{
    internal NavMeshAgent _navMeshAgent;
    internal RigidbodyCharacter _rigidbodyCharacter;

    [Header("Sight Settings")]
    public LayerMask sightLayerMask;
    public SightCone sightCone;

    void OnEnable()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _rigidbodyCharacter = GetComponent<RigidbodyCharacter>();
    }

    public void Update()
    {
        HandleStateMachine();
    }

    internal virtual void HandleStateMachine() { }

    /// <summary>Returns a bool based on field of view and Line of sight checks. (Can be Overridden)
    /// <param>The target of which to check against</param>
    /// </summary>
    public virtual bool CanSeeTarget(Transform target)
    {
        Vector3 dir = target.position - transform.position;
        float angle = Vector3.Angle(dir, GetLookDirection());

        //Check target is within sight cone.
        if (dir.magnitude <= sightCone.Range) //Magnitude is Distance.
        {
            if (angle <= sightCone.Angle * 0.5f) // Only perform the check if the target is within sight angle. (Prevents spamming un-used raycasts).
            {
                Ray ray = new Ray(_rigidbodyCharacter.GetEyeHeight(), dir);
                RaycastHit hit; // Assign Empty.
                Physics.interCollisionSettingsToggle = false;
                if (Physics.Raycast(ray, out hit, sightCone.Range, sightLayerMask)) // Check to see if the AI has line of sight to player.
                    //Return true if we hit the target, or a child of the target.
                    return hit.collider.transform == target || hit.collider.transform.IsChildOf(target);
            }
        }

        return false;
    }

    public virtual Vector3 GetLookDirection() { return transform.forward; }

    public EntityBase[] GetEntitiesInRange(float range, LayerMask mask)
    {
        List<EntityBase> foundEntities = new List<EntityBase>();
        Collider[] coll = Physics.OverlapSphere(transform.position, range, mask); // Find all colliders on layermask within range.

        for (int i = 0; i < coll.Length; i++)
        {
            if (coll[i].GetComponent<EntityBase>())
                foundEntities.Add(coll[i].GetComponent<EntityBase>()); //If it has a EntityBase component, then add it to the list.
        }

        return foundEntities.ToArray();
    }


    ///<summary>
    /// Cycle through an array of <paramref name="entities"> and find the best suited target based on targets score.
    ///</summary>
    public EntityBase GetBestSuitedTarget(EntityBase[] entities)
    {
        if (entities.Length == 0)
            return null;

        float lowestScore = GetTargetScore(entities[0]);
        EntityBase bestSuited = entities[0];
        for (int i = 0; i < entities.Length; i++)
        {
            float target = GetTargetScore(entities[i]);
            if (target < lowestScore)
            {
                bestSuited = entities[i];
                lowestScore = target;
            }
        }

        return bestSuited;
    }

    public virtual float GetTargetScore(EntityBase entity) // Lower score the better suited
    {
        return Vector3.Distance(transform.position, entity.transform.position);
    }

}

