using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public float MoveSpeed { get; private set; } = 5f;

    private Vector2 _axisInput = Vector2.zero;
    private Rigidbody2D _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Vector2 moveForce = _axisInput * MoveSpeed * Time.deltaTime;

        _rigidbody.AddForce(moveForce);
    }
    private void OnMove(InputValue value)
    {
       _axisInput = value.Get<Vector2>();
        
    }

    private void OnUse(InputValue value) 
    { }
}
