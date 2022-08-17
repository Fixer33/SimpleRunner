using UnityEngine;

public class PositionSetContestant : ContestantController
{
    protected override void Move()
    {
        transform.position = transform.position + Vector3.forward * _movementSpeed * Time.deltaTime;
    }
}
