using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    //Default mouse sensitivity for now..
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    float xRotation = 0f;

    private const string MOUSE_X = "Mouse X";
    private const string MOUSE_Y = "Mouse Y";

    // Start is called before the first frame update
    void Start()
    {
        //Locks the cursor on the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // multiplying by deltaTime to ensure that we are moving independent to our frame rate
        float mouseX = Input.GetAxis(MOUSE_X) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(MOUSE_Y) * mouseSensitivity * Time.deltaTime;

        // using += results in flipped rotations
        // This setup allows us to clamp the rotation, so that we cant look backwards
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
