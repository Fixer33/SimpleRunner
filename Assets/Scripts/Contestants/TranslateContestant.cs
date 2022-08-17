using UnityEngine;

public class TranslateContestant : ContestantController
{
    protected override void Move()
    {
        transform.Translate(Vector3.forward * _movementSpeed * Time.deltaTime);
    }
}
