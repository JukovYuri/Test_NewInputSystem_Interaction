using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class InputService
{
    public Vector2 Axis => GetAxis();

    public event Action JumpEvent;
    public event Action AttackModeEvent;
    public event Action MoveModeEvent;
    public event Action<float> ShootEvent;

    private Controls input;

    private Vector2 GetAxis()
    {
        //возвращает 0 если:
        //1. нет тача
        //2. тач по UI
        //3. тач по персонажу 
        return Vector2.zero;
    }



    private void OnEnable()
    {
        input.Enable();
    }

    private void Awake()
    {
        input = new Controls();
        input.Game.Touch.performed += OnTouch;
        input.Game.TouchPosition.performed += OnTouchPosition;
    }

    private void OnTouchPosition(InputAction.CallbackContext obj)
    {
        Vector2 pos = obj.ReadValue<Vector2>();
        Debug.Log(pos);
    }

    private void OnTouch(InputAction.CallbackContext obj)
    {
        IInputInteraction interaction = obj.interaction;

        switch (interaction)
        {
            case MultiTapInteraction:
                //если не
                //1. тач по UI
                //2. тач по персонажу

                JumpEvent.Invoke();
                Debug.Log("Jump");

                break;

            case PressInteraction:
                //если тач по персонажу, то запустить корутину проверки перехода в AimMode (коллайдер персонажу)
                //если тач не по прицелу, то переход в MoveMode (коллайдер прицела)
                Debug.Log("PressInteraction");
                break;

            case HoldInteraction:
                //
                Debug.Log("HoldInteraction");
                break;
        }
    }

    private void OnDisable()
    {
        input.Disable();
    }
}
