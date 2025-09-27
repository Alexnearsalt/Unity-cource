using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] private DiceJump diceJump;
    [SerializeField] private GameRuntime gameRuntime;
    
    private Controls _controls;
    private InputAction _jumpAction;

    private void Awake()
    {
        _controls = new Controls();
        _controls.Enable();

        diceJump = GetComponent<DiceJump>();
        
        _jumpAction = _controls.Gameplay.Jump;
    }

    private void OnEnable()
    {
        _jumpAction.performed += OnJumpPerformed;
        _controls.Gameplay.Reset.performed += OnResetPerformed;
        _controls.Gameplay.Rebind.performed += OnRebindPerformed;
    }

    private void OnDisable()
    {
        _jumpAction.performed -= OnJumpPerformed;
        _controls.Gameplay.Reset.performed -= OnResetPerformed;
        _controls.Gameplay.Rebind.performed -= OnRebindPerformed;
    }

    private void OnJumpPerformed(InputAction.CallbackContext obj)
    {
        DiceJump[] allDice = FindObjectsByType<DiceJump>(FindObjectsSortMode.InstanceID);

        foreach (DiceJump dice in allDice)
        {
            dice.Jump();
        }

        Debug.Log("Jump");
    }

    private void OnResetPerformed(InputAction.CallbackContext obj)
    {
        gameRuntime.ResetScore();
        Debug.Log("Score = 0");
    }

    private void OnRebindPerformed(InputAction.CallbackContext obj)
    {
        Debug.Log("Start rebinding");

        _jumpAction.Disable();

        _jumpAction.PerformInteractiveRebinding()
            .WithTargetBinding(0)
            .WithControlsExcluding("Mouse")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation =>
            {
                Debug.Log("Jump rebound to new button");
                operation.Dispose();
                _jumpAction.Enable();
            })
            .Start();
    }
}