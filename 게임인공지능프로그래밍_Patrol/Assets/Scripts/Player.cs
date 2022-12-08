using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    
    CharacterController characterController;
    MyPlayerActions inputActions;
    Vector3 dir;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        inputActions = new MyPlayerActions();
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }

    private void Update()
    {
        characterController.Move(moveSpeed * Time.deltaTime * dir);        
    }

    private void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<Vector2>();
        dir = new(move.x, 0, move.y);
    }
}
