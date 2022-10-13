using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySlot : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject hasKeyText;
    public GameObject noKeyText;
    public GameObject player;

    public Material activatedTrim;

    public MeshRenderer lockMeshRenderer;
    public int lockMaterialIndex;

    public GameObject Quadrants;

    private Material lockTrim;

    private GameObject key;

    private Transform playerCameraTransform;
    private Transform textCanvasTransform;
    private Vector3 playerCameraPosition;
    private Vector3 playerCameraVector;
    private Vector3 slotPosition;
    private Vector3 lineToSlot;

    private bool keyPlaced;

    // Start is called before the first frame update
    void Start()
    {
        playerCameraTransform = playerCamera.transform;
        playerCameraPosition = playerCameraTransform.position;
        playerCameraVector = playerCameraTransform.forward * -1;

        slotPosition = transform.position;

        lineToSlot = playerCameraPosition - slotPosition;

        keyPlaced = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(keyPlaced)
        {
          return;
        }

        //float heightAdjust = Mathf.Sin(Time.fixedTime * (float)2) * (float)0.1;

        playerCameraPosition = playerCameraTransform.position;
        playerCameraVector = playerCameraTransform.forward * -1;

        //keyPosition = transform.position;
        //keyPosition.y = baseHeight + heightAdjust;
        //transform.position = keyPosition;

        slotPosition = transform.position;
        lineToSlot = playerCameraPosition - slotPosition;

        if(Vector3.Distance(playerCameraPosition, transform.position) < 4)
        {
          if(Vector3.Angle(playerCameraVector, lineToSlot) < (float)10)
          {
            bool hasKey = false;

            foreach(Transform T in player.transform)
            {
              if(T.gameObject.tag == "Key")
              {
                hasKey = true;
                key = T.gameObject;
              }
            }

            if(hasKey)
            {
              noKeyText.SetActive(false);
              hasKeyText.SetActive(true);
              hasKeyText.transform.LookAt(playerCameraTransform);

              if(Input.GetButtonDown("Interact"))
              {
                key.transform.SetParent(transform);
                key.transform.localPosition = new Vector3(0,0,0);
                key.transform.localEulerAngles = new Vector3(0,0,0);
                hasKeyText.SetActive(false);
                lockTrim = lockMeshRenderer.materials[lockMaterialIndex];
                lockTrim.CopyPropertiesFromMaterial(activatedTrim);

                bool allKeysPlaced = true;
                foreach(Transform T in Quadrants.transform)
                {
                  if(T.gameObject.activeInHierarchy)
                  {
                    allKeysPlaced = false;
                  }
                }

                if(allKeysPlaced)
                {
                  Debug.Log("Angels win!");
                  return;
                }

                while(!allKeysPlaced)
                {
                    int random_quadrant_index = Random.Range(0,4);
                    if(Quadrants.transform.GetChild(random_quadrant_index).gameObject.activeInHierarchy)
                    {
                      Quadrants.transform.GetChild(random_quadrant_index).gameObject.SetActive(false);
                      break;
                    }
                }

                keyPlaced = true;
              }
            }
            else
            {
              hasKeyText.SetActive(false);
              noKeyText.SetActive(true);
              noKeyText.transform.LookAt(playerCameraTransform);
            }
          }
          else
          {
            hasKeyText.SetActive(false);
            noKeyText.SetActive(false);
          }
        }
        else
        {
          hasKeyText.SetActive(false);
          noKeyText.SetActive(false);
        }
    }

    void FixedUpdate()
    {

    }
}
