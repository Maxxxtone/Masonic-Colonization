using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Transform _body;
    private Rigidbody2D _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    //by mouse position
    public void RotateBody(Vector2 mousePosition)
    {
        if (mousePosition.x > 0)
            transform.localEulerAngles = Vector3.zero;
        else if (mousePosition.x < 0)
            transform.localEulerAngles = new Vector3(0, 180, 0);
    }
    public void Move(Vector2 direction)
    {
        _rb.velocity = direction * _moveSpeed;
    }
    public void StopMove()
    {
        _rb.velocity = Vector2.zero;
    }
}
