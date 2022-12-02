using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SwordThrowing : MonoBehaviour
{
    public bool isRightHand;
    public GameObject banishedSword;
    public GameObject otherEvilSword;
    private Transform indexFingerTransform;
    public float throwDelay;

    private bool triggerIsDown;
    private bool triggerIsDown2;
    private bool canThrowSword;

    private float lastThrown;
    private bool gameHasStarted;
    private bool tooLow;

    // Start is called before the first frame update
    void Start()
    {
        triggerIsDown = false;
        triggerIsDown2 = false;
        canThrowSword = true;
        gameHasStarted = false;
        tooLow = false;
    }

    // Update is called once per frame
    void Update()
    {
        canThrowSword = (Time.realtimeSinceStartup - lastThrown) > throwDelay;
        tooLow = transform.position.y < (float)10;

        foreach(GameObject cube in GameObject.FindGameObjectsWithTag("StartGame"))
        {
          gameHasStarted = true;
        }

        if (isRightHand)
        {
            triggerIsDown = SteamVR_Input.GetState("GrabPinch", SteamVR_Input_Sources.RightHand);
            triggerIsDown2 = SteamVR_Input.GetState("GrabGrip", SteamVR_Input_Sources.RightHand);
        }
        else
        {
            triggerIsDown = SteamVR_Input.GetState("GrabPinch", SteamVR_Input_Sources.LeftHand);
            triggerIsDown2 = SteamVR_Input.GetState("GrabGrip", SteamVR_Input_Sources.LeftHand);
        }

        if (triggerIsDown && canThrowSword && isRightHand && triggerIsDown2 && gameHasStarted && !tooLow)
        {
            Transform spawnSwordTransform = transform;
            if (transform.childCount > 5)
            {
                spawnSwordTransform = transform.GetChild(5).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(1).GetChild(0);
            }
            GameObject newSword = GameObject.Instantiate(banishedSword, spawnSwordTransform.position, transform.rotation);
            lastThrown = Time.realtimeSinceStartup;

            Vector3 throwDirection = spawnSwordTransform.right;

            if (transform.childCount > 5)
            {
                Transform indexFingerTransform = transform.GetChild(5).GetChild(0).GetChild(0).GetChild(0).GetChild(0);
                throwDirection = indexFingerTransform.TransformDirection(indexFingerTransform.InverseTransformDirection(indexFingerTransform.forward) + new Vector3((float)0.3, (float) 0.3, (float)6));
            }

            Vector3 throwTargetPosition = spawnSwordTransform.position + throwDirection * 100;
            newSword.transform.LookAt(throwTargetPosition);
        }

        if (triggerIsDown && canThrowSword && !isRightHand && triggerIsDown2 && gameHasStarted && !tooLow)
        {
            Transform spawnSwordTransform = transform;
            if (transform.childCount > 5)
            {
                spawnSwordTransform = transform.GetChild(5).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(1).GetChild(0);
            }
            GameObject newSword = GameObject.Instantiate(otherEvilSword, spawnSwordTransform.position, transform.rotation);
            lastThrown = Time.realtimeSinceStartup;

            Vector3 throwDirection = spawnSwordTransform.right;

            if (transform.childCount > 5)
            {
                Transform indexFingerTransform = transform.GetChild(5).GetChild(0).GetChild(0).GetChild(0).GetChild(0);
                throwDirection = indexFingerTransform.TransformDirection(indexFingerTransform.InverseTransformDirection(indexFingerTransform.forward) + new Vector3((float)0.3, (float) 0.3, (float)6));
            }

            Vector3 throwTargetPosition = spawnSwordTransform.position + throwDirection * 100;
            newSword.transform.LookAt(throwTargetPosition);
        }
    }
}
