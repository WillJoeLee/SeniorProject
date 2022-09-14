using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //default mouse sensitivity for now..
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    float xRotation = 0f;

    private const string MOUSE_X = "Mouse X";
    private const string MOUSE_Y = "Mouse Y";

    //start is called before the first frame update
    void Start()
    {
        //locks the cursor on the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    //update is called once per frame
    void Update()
    {
        //multiplying by deltaTime to ensure that we are moving independent to our frame rate
        float mouseX = Input.GetAxis(MOUSE_X) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(MOUSE_Y) * mouseSensitivity * Time.deltaTime;

        //using += results in flipped rotations
        xRotation -= mouseY;
        //this setup allows us to clamp the rotation, so that we cant look backwards
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
