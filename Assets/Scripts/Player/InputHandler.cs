using System;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class InputHandler : MonoBehaviour
{
    public event Action MeleeAttackButtonTriggered, RangeAttackButtonTriggered, RangeAttackButtonReleased;
    private PlayerInput _input;
    public Vector2 MovementDirection => _input.Player.Move.ReadValue<Vector2>();
    public Vector2 MousePosition => _input.Player.MousePosition.ReadValue<Vector2>();
    public Vector2 WorldMousePosition => Camera.main.ScreenToWorldPoint(MousePosition);
    private void Awake()
    {
        _input = new PlayerInput();
    }
    private void OnEnable()
    {
        _input.Enable();
        _input.Player.MeleeAttack.performed += _ => MeleeAttackButtonTriggered?.Invoke();
        _input.Player.Shoot.started += context =>
        {
            if (context.interaction is HoldInteraction)
                RangeAttackButtonTriggered?.Invoke();
        };
        _input.Player.Shoot.canceled += _ => RangeAttackButtonReleased?.Invoke();
    }

    private void Shoot_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }

    private void OnDisable()
    {
        _input.Player.MeleeAttack.performed -= _ => MeleeAttackButtonTriggered?.Invoke();
        _input.Player.Shoot.performed -= _ => RangeAttackButtonTriggered?.Invoke();
        _input.Disable();
    }
}
