using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementPlayer : MonoBehaviour
{
    // Variables
    [Header("Player Controls")]
    public InputAction moveAction;

    public float Speed = 1;

    private Rigidbody2D oRigidBody;

    // Functions
    private void Awake()
    {
        oRigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 oldValue = oRigidBody.velocity;
        Vector2 newValue = moveAction.ReadValue<Vector2>().normalized * Speed;

        newValue = Vector2.Lerp(oldValue, newValue, .1f);
        oRigidBody.velocity = newValue;
    }

    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }
}
