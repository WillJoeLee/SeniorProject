using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    //default speed for now
    public float speed = 12f;

    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    //update is called once per frame
    void Update()
    {
        float x = Input.GetAxis(HORIZONTAL);
        float z = Input.GetAxis(VERTICAL);

        Vector3 move = transform.right * x + transform.forward * z;

        //allow the movement to be frame rate independent by multiplying by Time.deltaTime
        controller.Move(move * speed * Time.deltaTime);
    }
}
