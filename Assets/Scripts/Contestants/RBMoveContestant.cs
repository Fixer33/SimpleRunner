using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RBMoveContestant : ContestantController
{
    private Rigidbody _rb;

    private new void Start()
    {
        base.Start();
        _rb = GetComponent<Rigidbody>();
    }

    protected override void Move()
    {
        _rb.MovePosition(_rb.position + Vector3.forward * _movementSpeed * Time.deltaTime);
    }
}
