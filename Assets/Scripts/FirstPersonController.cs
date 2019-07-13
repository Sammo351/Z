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

    public void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        MoveInDirection(transform.TransformDirection(new Vector3(h, 0, v)));
        IsGrounded();
    }
}
