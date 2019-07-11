using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 15f;

    private Rigidbody _rigidbody;
    private CapsuleCollider _capsuleCollider;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    public Vector3 GetCenter()
    {
        return transform.position + _capsuleCollider.center;
    }

    public Vector3 GetFeetPosition()
    {
        Vector3 pos = transform.position;
        pos -= _capsuleCollider.center;
        pos -= Vector3.up * 0.5f * _capsuleCollider.height;
        return pos;
    }

    public Vector3 GetEyeHeight()
    {
        Vector3 pos = GetCenter();
        float eyePos = pos.y + (0.4f * _capsuleCollider.height);
        pos.y = eyePos;
        return pos;
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
