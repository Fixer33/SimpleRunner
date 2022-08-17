using UnityEngine;

public class LerpContestant : ContestantController
{
    protected override void Move()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.forward, Time.deltaTime * _movementSpeed);
    }
}
