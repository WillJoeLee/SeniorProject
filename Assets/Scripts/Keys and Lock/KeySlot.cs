using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeySlot : MonoBehaviour
{
    private GameObject playerCamera;
    public GameObject hasKeyText;
    public GameObject noKeyText;
    private GameObject player;

    public Material activatedTrim;

    public MeshRenderer lockMeshRenderer;
    public int lockMaterialIndex;

    public GameObject Quadrants;
    public Transform EnemySpawners;

    private InputActionAsset playerInputActionAsset;

    private Material lockTrim;

    private GameObject key;

    private Transform playerCameraTransform;
    private Transform textCanvasTransform;
    private Vector3 playerCameraPosition;
    private Vector3 playerCameraVector;
    private Vector3 slotPosition;
    private Vector3 lineToSlot;

    private bool keyPlaced;

    public GameObject winInform;
    public GameObject CueManager;
    private Runes runes;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GameObject.FindWithTag("MainCamera");
        playerCameraTransform = playerCamera.transform;
        playerCameraPosition = playerCameraTransform.position;
        playerCameraVector = playerCameraTransform.forward * -1;
        player = playerCameraTransform.parent.gameObject;
        runes = player.GetComponent<Runes>();

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
        playerCamera = playerCameraTransform.gameObject;
        player = playerCameraTransform.parent.gameObject;
        runes = player.GetComponent<Runes>();
        playerInputActionAsset = player.GetComponent<PlayerInput>().actions;

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

              bool interact = playerInputActionAsset.actionMaps[0].actions[7].ReadValue<float>() == 1;
              if(interact)
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

                if (key.name == "Key 1")
                  runes.setRuneEactive();
                else if (key.name == "Key 2")
                  runes.setRuneHactive();
                else if (key.name == "Key 3")
                  runes.setRuneRactive();
                else
                  runes.setRuneXactive();
                CueManager.GetComponent<GameCues>().setCueText(2);

                if(allKeysPlaced)
                {
                  if (winInform.TryGetComponent<GameEnd>(out GameEnd yaywewon))
                            {
                                yaywewon.winGame = true;
                            }
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

                foreach (Transform i in EnemySpawners)
                        {
                            foreach (Transform j in i)
                            {
                                if (j.TryGetComponent<EnemySpawner>(out EnemySpawner k))
                                {
                                    k.atOnceMax += 10;
                                }
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
