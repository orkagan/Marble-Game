using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : PowerUp
{
    [SerializeField] protected float _speed;
    protected override void PowerUpActivate(GameObject marble)
    {
        Rigidbody rb = marble.GetComponent<Rigidbody>();

        if (!rb) return;
        rb.AddForce(rb.velocity.normalized * _speed, ForceMode.VelocityChange);
    }
}
