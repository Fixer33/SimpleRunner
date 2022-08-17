using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public static UnityEvent OnPointerDown = new UnityEvent();
    public static UnityEvent OnPointerUp = new UnityEvent();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            OnPointerDown.Invoke();
        }
        else if (Input.GetMouseButton(0) == false && Input.touchCount < 1)
        {
            OnPointerUp.Invoke();
        }
    }
}
