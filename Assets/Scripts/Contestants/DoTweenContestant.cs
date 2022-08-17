using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

public class DoTweenContestant : ContestantController
{
    private TweenerCore<Vector3, Vector3, VectorOptions> _movementAction;

    private new void Start()
    {
        base.Start();
        var finishObj = FindObjectOfType<Finish>();
        float distance = finishObj.transform.position.z - transform.position.z;
        _movementAction = transform.DOMoveZ(finishObj.transform.position.z, distance / _movementSpeed).SetEase(Ease.Linear);
        _movementAction.Pause();
    }
    private new void OnDestroy()
    {
        base.OnDestroy();
        _movementAction.Kill();
    }

    private void Update()
    {
        if (_movementAction == null || _movementAction.IsActive() == false)
            return;

        if (_isMoving && _movementAction.IsPlaying() == false)
        {
            _movementAction.Play();
        }
        else if (_isMoving == false && _movementAction.IsPlaying() == true)
        {
            _movementAction.Pause();
        }
    }

    protected override void Move()
    {
        
    }
}
