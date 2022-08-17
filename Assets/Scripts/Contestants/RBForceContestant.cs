using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RBForceContestant : ContestantController
{
    private Rigidbody _rb;

    private new void Start()
    {
        base.Start();
        _rb = GetComponent<Rigidbody>();
    }

    protected override void Move()
    {
        _rb.AddForce(Vector3.forward * _movementSpeed * Time.deltaTime, ForceMode.VelocityChange);
    }
}
