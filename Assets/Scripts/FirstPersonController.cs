using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : RigidbodyCharacter
{
    [Range(0, 15f)]
    public float movementSpeed = 5f;
    [Range(0, 15f)]
    public float rotationSpeed = 15f;

    public DamageHandler testHandler;


    public void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        MoveInDirection(transform.TransformDirection(new Vector3(h, 0, v)));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DamageSystem.DamageEntity(testHandler, new DamagePacket(DamageType.Fire, 3f), new DamagePacket(DamageType.Piercing, 1f));
        }
    }

    public DamageType damgeType;


}
