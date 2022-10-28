using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody;
    public PlayerInput playerInput;
    private InputActionAsset playerInputActionAsset;

    //default mouse sensitivity for now..
    public float mouseSensitivity = 50f;
    public float controllerSensitivity = 300f;
    public float ySensitivityControllerReduction = 0.5f;

    private const string MOUSE_X = "Mouse X";
    private const string MOUSE_Y = "Mouse Y";
    private const int IN_MAIN_MENU = 0;

    float xRotation = 0f;

    //start is called before the first frame update
    void Start()
    {
        playerInputActionAsset = playerInput.actions;
        //Checks to see if the player is out of the main menu
        if (SceneManager.GetActiveScene().buildIndex != IN_MAIN_MENU)
        {
            //locks the cursor on the screen
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    //update is called once per frame
    void Update()
    {
        bool isController = false;
        try
        {
          Debug.Log(playerInputActionAsset.actionMaps[0].actions[2].activeControl.displayName);
          isController = playerInputActionAsset.actionMaps[0].actions[2].activeControl.displayName == "Right Stick";
        }
        catch(System.NullReferenceException){}

        float inputLookX = playerInputActionAsset.actionMaps[0].actions[2].ReadValue<Vector2>().x;
        float inputLookY = playerInputActionAsset.actionMaps[0].actions[2].ReadValue<Vector2>().y;

        float sensitivity = mouseSensitivity;
        float yFactor = 1f;
        if(isController)
        {
          sensitivity = controllerSensitivity;
          yFactor = ySensitivityControllerReduction;
        }

        //multiplying by deltaTime to ensure that we are moving independent to our frame rate
        float mouseX = inputLookX * sensitivity * Time.deltaTime;
        float mouseY = inputLookY * sensitivity * yFactor * Time.deltaTime;

        //using += results in flipped rotations
        xRotation -= mouseY;
        //this setup allows us to clamp the rotation, so that we cant look backwards
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
