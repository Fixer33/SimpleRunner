using UnityEngine;

public class MoveTowardContestant : ContestantController
{
    protected override void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.forward, Time.deltaTime * _movementSpeed);
    }
}
