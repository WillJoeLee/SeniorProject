using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject text;

    private Transform playerCameraTransform;
    private Transform textCanvasTransform;
    private Vector3 playerCameraPosition;
    private Vector3 playerCameraVector;
    private Vector3 keyPosition;
    private Vector3 lineToKey;

    // Start is called before the first frame update
    void Start()
    {
        playerCameraTransform = playerCamera.transform;
        playerCameraPosition = playerCameraTransform.position;
        playerCameraVector = playerCameraTransform.forward * -1;

        keyPosition = transform.position;

        lineToKey = playerCameraPosition - keyPosition;
    }

    // Update is called once per frame
    void Update()
    {
        playerCameraPosition = playerCameraTransform.position;
        playerCameraVector = playerCameraTransform.forward * -1;

        keyPosition = transform.position;

        lineToKey = playerCameraPosition - keyPosition;

        if(Vector3.Distance(playerCameraPosition, transform.position) < 3)
        {
          if(Vector3.Angle(playerCameraVector, lineToKey) < (float)10)
          {
            text.SetActive(true);
            text.transform.LookAt(playerCameraTransform);
            if(Input.GetButtonDown("Interact"))
            {
              Debug.Log("It worked!");
            }
          }
          else
          {
            text.SetActive(false);
          }
        }
        else
        {
          text.SetActive(false);
        }

        //Debug.Log(Vector3.Angle(playerCameraVector, lineToKey));

    }
}
