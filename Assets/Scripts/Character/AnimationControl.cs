using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class AnimationControl : MonoBehaviour
{
    [SerializeField] private Animator Animator;

    private MovementController _controller;

    private void Start()
    {
        if (Animator == null)
            throw new System.Exception("No animator assigned to " + gameObject.name);

        _controller = GetComponent<MovementController>();
        _controller.RunningStateChanged.AddListener(SetRunningState);
        Events.PlayerFinished.AddListener(TriggerFinish);
    }
    private void OnDestroy()
    {
        _controller.RunningStateChanged.RemoveListener(SetRunningState);
        Events.PlayerFinished.RemoveListener(TriggerFinish);
    }

    public void SetRunningState(bool isRunning)
    {
        const string runningBoolName = "isRunning";

        bool currentState = Animator.GetBool(runningBoolName);
        if (currentState != isRunning)
        {
            Animator.SetBool(runningBoolName, isRunning);
        }
    }

    public void TriggerFinish()
    {
        const string finishTriggerName = "Finished";
        Animator.SetTrigger(finishTriggerName);
    }
}
