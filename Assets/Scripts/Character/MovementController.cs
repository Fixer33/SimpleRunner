using UnityEngine;
using UnityEngine.Events;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float MovementSpeed;
    
    public UnityEvent<bool> RunningStateChanged = new UnityEvent<bool>();

    private bool _isRunning = false;
    private bool _ignoreInput = false;

    private void Start()
    {
        InputManager.OnPointerDown.AddListener(OnPointerDown);
        InputManager.OnPointerUp.AddListener(OnPointerUp);
        Events.PlayerFinished.AddListener(Finished);
    }
    private void OnDestroy()
    {
        InputManager.OnPointerDown.RemoveListener(OnPointerDown);
        InputManager.OnPointerUp.RemoveListener(OnPointerUp);
        Events.PlayerFinished.RemoveListener(Finished);
    }

    private void FixedUpdate()
    {
        if (_isRunning)
        {
            transform.Translate(transform.forward * MovementSpeed * Time.deltaTime);
        }
    }

    private void OnPointerDown()
    {
        SetRunningState(true);
    }
    private void OnPointerUp()
    {
        SetRunningState(false);
    }

    private void SetRunningState(bool isRunning)
    {
        if (_ignoreInput)
            return;

        _isRunning = isRunning;
        RunningStateChanged.Invoke(isRunning);
    }
    private void Finished()
    {
        SetRunningState(false);
        _ignoreInput = true;
    }
}
