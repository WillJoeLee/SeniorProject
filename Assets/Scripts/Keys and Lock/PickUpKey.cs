using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject text;
    public GameObject player;

    private Transform playerCameraTransform;
    private Transform textCanvasTransform;
    private Vector3 playerCameraPosition;
    private Vector3 playerCameraVector;
    private Vector3 keyPosition;
    private Vector3 lineToKey;

    private bool pickedUp;
    private float baseHeight;

    // Start is called before the first frame update
    void Start()
    {
        playerCameraTransform = playerCamera.transform;
        playerCameraPosition = playerCameraTransform.position;
        playerCameraVector = playerCameraTransform.forward * -1;

        keyPosition = transform.position;

        lineToKey = playerCameraPosition - keyPosition;

        pickedUp = false;

        baseHeight = (float)1;
    }

    // Update is called once per frame
    void Update()
    {
        if(pickedUp)
        {
          return;
        }

        //float heightAdjust = Mathf.Sin(Time.fixedTime * (float)2) * (float)0.1;

        playerCameraPosition = playerCameraTransform.position;
        playerCameraVector = playerCameraTransform.forward * -1;

        //keyPosition = transform.position;
        //keyPosition.y = baseHeight + heightAdjust;
        //transform.position = keyPosition;

        lineToKey = playerCameraPosition - keyPosition;

        if(Vector3.Distance(playerCameraPosition, transform.position) < 3)
        {
          if(Vector3.Angle(playerCameraVector, lineToKey) < (float)10)
          {
            text.SetActive(true);
            text.transform.LookAt(playerCameraTransform);

            if(Input.GetButtonDown("Interact"))
            {
              transform.SetParent(player.transform);
              transform.localEulerAngles = new Vector3(0,180,0);
              transform.localPosition = new Vector3(0,0,(float)(-0.5));
              pickedUp = true;
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
    }

    void FixedUpdate()
    {
      if(!pickedUp)
      {
        transform.RotateAround(transform.position, Vector3.up, (float)0.8);

        float heightAdjust = Mathf.Sin(Time.fixedTime * (float)2) * (float)0.1;
        Vector3 keyPosition = transform.position;
        keyPosition.y = baseHeight + heightAdjust;
        transform.position = keyPosition;

        Vector3 textPosition = text.transform.position;
        text.transform.position = new Vector3(textPosition.x,
                                              baseHeight + (float)0.5,
                                              textPosition.z);
      }

    }
}
