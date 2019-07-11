using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class RigidbodyCharacter : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private CapsuleCollider _capsuleCollider;

    [Flags]
    public enum CharacterStates
    {
        CanMove,
        IsGrounded
    }

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();

        SetupRigidbody();
    }

    internal void MoveInDirection(Vector3 dir)
    {
        _rigidbody.MovePosition(transform.position + dir);
    }

    internal void MoveToPoint(Vector3 point)
    {
        _rigidbody.MovePosition(point);
    }

    public Vector3 GetCenter()
    {
        if (_capsuleCollider)
            return transform.position + _capsuleCollider.center;

        return transform.position;
    }

    public Vector3 GetFeetPosition()
    {

        Vector3 pos = transform.position;
        if (_capsuleCollider)
        {
            pos -= _capsuleCollider.center;
            pos -= Vector3.up * 0.5f * _capsuleCollider.height;
        }
        else
        {
            pos -= Vector3.up * 0.5f * 1.8f; //Assume default height of 1.8m.
        }
        return pos;
    }

    public Vector3 GetEyeHeight()
    {
        Vector3 pos = GetCenter();
        float eyePos = pos.y;

        if (_capsuleCollider)
            eyePos = pos.y + (0.4f * _capsuleCollider.height);
        else
            eyePos = pos.y + (0.4f * 1.8f); // Assume default height 1.8m.

        pos.y = eyePos;
        return pos;
    }

    public void SetupRigidbody()
    {
        if (_rigidbody.mass <= 1)
            _rigidbody.mass = 80;

        _rigidbody.constraints |= RigidbodyConstraints.FreezeRotation;
        _rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(GetCenter(), GetFeetPosition());
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GetFeetPosition(), 0.1f);
        Matrix4x4 rotationMatrix = Matrix4x4.TRS(GetEyeHeight(), transform.rotation, Vector3.one);
        Gizmos.matrix = rotationMatrix;
        Gizmos.DrawWireCube(Vector3.forward, new Vector3(1f, 0.3f, 1f));

    }



}
