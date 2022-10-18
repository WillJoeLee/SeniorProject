using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    //default speed for now
    public float speed = 12f;

    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    //variables for jumping & falling
    Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 3f;

    public InputActionAsset playerInputActionAsset;

    //update is called once per frame
    void Update()
    {
        //jumping and falling checks added here
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        float x = playerInputActionAsset.actionMaps[0].actions[0].ReadValue<Vector2>().x;
        float z = playerInputActionAsset.actionMaps[0].actions[0].ReadValue<Vector2>().y;

        //Debug.Log(playerInputActionAsset.actionMaps[0].actions[0].ReadValue<Vector2>());

        Vector3 move = transform.right * x + transform.forward * z;

        //allow the movement to be frame rate independent by multiplying by Time.deltaTime
        controller.Move(move * speed * Time.deltaTime);

        bool jumpBool = playerInputActionAsset.actionMaps[0].actions[1].ReadValue<float>() == (float)1;
        //jumping and falling mechanics added here
        if (jumpBool && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
