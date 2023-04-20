using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

[RequireComponent(typeof(CharacterController))]
public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float horizontalSensitivity;
    public float verticalSensitivity;

    public Camera cam;

    PlayerInput playerInput;
    CharacterController characterController;
    InputAction moveAction;
    InputAction lookAction;

    float velocityY = 0;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        lookAction = playerInput.actions["Look"];
    }

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        var d = lookAction.ReadValue<Vector2>();
        // Rotate camera up/down
        Vector3 currentAngle = cam.transform.eulerAngles;
        float x = currentAngle.x - d.y * verticalSensitivity;
        if (x > 85 && x < 275)
        {
            float a = Mathf.Abs(x - 85);
            float b = Mathf.Abs(x - 275);
            if (a < b)
            {
                x = 85;
            } else
            {
                x = 275;
            }
        }
        cam.transform.localEulerAngles = new Vector3(x, 0, 0);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // Rotate player left/right
        Vector3 playerAngle = transform.eulerAngles;
        float y = playerAngle.y + d.x * horizontalSensitivity;
        transform.eulerAngles = new Vector3(0, y, 0);

        // Move player
        var v = moveAction.ReadValue<Vector2>();
        Vector3 move = v.y * transform.forward + v.x * transform.right;
        move.Normalize();
        characterController.Move(move * Time.deltaTime * speed);

        ApplyGravity();
    }

    private void ApplyGravity()
    {
        if (!characterController.isGrounded)
        {
            velocityY += -9.81f * Time.deltaTime;
            characterController.Move(new Vector3(0, velocityY, 0));
        } else
        {
            velocityY = 0;
        }
    }
}
