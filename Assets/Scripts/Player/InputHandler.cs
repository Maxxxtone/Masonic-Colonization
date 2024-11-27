using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public event Action AttackButtonTriggered;
    private PlayerInput _input;
    public Vector2 MovementDirection => _input.Player.Move.ReadValue<Vector2>();
    public Vector2 MousePosition => _input.Player.MousePosition.ReadValue<Vector2>();
    private void Awake()
    {
        _input = new PlayerInput();
    }
    private void OnEnable()
    {
        _input.Enable();
        _input.Player.Attack.performed += _ => AttackButtonTriggered?.Invoke();
    }
    private void OnDisable()
    {
        _input.Player.Attack.performed -= _ => AttackButtonTriggered?.Invoke();
        _input.Disable();
    }
}
