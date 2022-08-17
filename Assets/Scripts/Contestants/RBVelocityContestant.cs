using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RBVelocityContestant : ContestantController
{
    private Rigidbody _rb;

    private new void Start()
    {
        base.Start();
        _rb = GetComponent<Rigidbody>();
    }

    protected override void Move()
    {
        _rb.velocity = Vector3.forward * _movementSpeed;
    }
}
