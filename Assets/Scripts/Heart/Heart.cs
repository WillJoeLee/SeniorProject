using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Heart : MonoBehaviour
{
    public GameObject heartsParent;
    private GameObject playerCamera;
    public GameObject text;
    private GameObject player;
    public GameObject heartSpawns;
    public bool DebugMode;
    private InputActionAsset playerInputActionAsset;

    private Transform playerCameraTransform;
    private Transform textCanvasTransform;
    private Vector3 playerCameraPosition;
    private Vector3 playerCameraVector;
    private Vector3 heartPosition;
    private Vector3 lineToHeart;

    private bool pickedUp;
    private float baseHeight;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerInputActionAsset = player.GetComponent<PlayerInput>().actions;
        playerCamera = GameObject.FindWithTag("MainCamera");
        playerCameraTransform = playerCamera.transform;
        playerCameraPosition = playerCameraTransform.position;
        playerCameraVector = playerCameraTransform.forward * -1;

        heartPosition = transform.position;

        lineToHeart = playerCameraPosition - heartPosition;

        pickedUp = false;

        if(!DebugMode)
        {
          int random_spawn_index = Random.Range(0,heartSpawns.transform.childCount);
          transform.position = heartSpawns.transform.GetChild(random_spawn_index).position;
        }

        baseHeight = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(pickedUp)
        {
          if (heartsParent.TryGetComponent<Hearts>(out Hearts parentHearts))
          {
            parentHearts.trueDeath++;
          }
          if (player.TryGetComponent<Health>(out Health revive))
          {
            revive.Respawn2();
          }
          pickedUp = false;
          return;
        }

        //float heightAdjust = Mathf.Sin(Time.fixedTime * (float)2) * (float)0.1;

        Transform nearestPlayerCameraTransform = GameObject.FindWithTag("MainCamera").transform;
        foreach(GameObject playerCamera in GameObject.FindGameObjectsWithTag("MainCamera"))
        {
          if(Vector3.Distance(transform.position, playerCamera.transform.position)
          < Vector3.Distance(transform.position, nearestPlayerCameraTransform.position))
          {
            nearestPlayerCameraTransform = playerCamera.transform;
          }
        }
        playerCameraTransform = nearestPlayerCameraTransform;
        player = playerCameraTransform.parent.gameObject;

        if(!player.GetComponent<Health>().isDead)
        {
          return;
        }

        playerInputActionAsset = player.GetComponent<PlayerInput>().actions;

        playerCameraPosition = playerCameraTransform.position;
        playerCameraVector = playerCameraTransform.forward * -1;

        //heartPosition = transform.position;
        //heartPosition.y = baseHeight + heightAdjust;
        //transform.position = heartPosition;

        heartPosition = transform.position;
        lineToHeart = playerCameraPosition - heartPosition;

        if(Vector3.Distance(playerCameraPosition, transform.position) < 3)
        {
          if(Vector3.Angle(playerCameraVector, lineToHeart) < (float)10)
          {
            text.SetActive(true);
            text.transform.LookAt(playerCameraTransform);

            bool interact = playerInputActionAsset.actionMaps[0].actions[7].ReadValue<float>() == 1;
            if(interact)
            {
              transform.SetParent(player.transform);
              transform.localEulerAngles = new Vector3(0,180,0);
              transform.localPosition = new Vector3(0,0,(float)(-0.5));
              pickedUp = true;
              text.SetActive(false);
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
        Vector3 heartPosition = transform.position;
        heartPosition.y = baseHeight + heightAdjust;
        transform.position = heartPosition;

        Vector3 textPosition = text.transform.position;
        text.transform.position = new Vector3(textPosition.x,
                                              baseHeight + (float)0.5,
                                              textPosition.z);
      }

    }
}
