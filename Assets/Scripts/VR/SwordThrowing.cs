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

    // Start is called before the first frame update
    void Start()
    {
        triggerIsDown = false;
        triggerIsDown2 = false;
        canThrowSword = true;


    }

    // Update is called once per frame
    void Update()
    {
        // Fix incorrect index finger location
        /*
        if(!isRightHand)
        {
          Transform indexFinger = transform.GetChild(5).GetChild(0).GetChild(0).GetChild(0).GetChild(2);
          //indexFinger.SetLocalPositionAndRotation(new Vector3(indexFinger.localPosition.x, indexFinger.localPosition.y, (float)0.04), indexFinger.localRotation);
          indexFinger.localPosition = new Vector3(indexFinger.localPosition.x, indexFinger.localPosition.y, (float)0.04);
        }*/

        canThrowSword = (Time.realtimeSinceStartup - lastThrown) > throwDelay;

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

        if (triggerIsDown && canThrowSword && isRightHand && triggerIsDown2)
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
                throwDirection = transform.GetChild(5).GetChild(0).GetChild(0).GetChild(0).GetChild(0).forward;
            }

            Vector3 throwTargetPosition = spawnSwordTransform.position + throwDirection * 100;
            newSword.transform.LookAt(throwTargetPosition);
        }

        /*
        if (triggerIsDown2 && canThrowSword)
        {
            Transform spawnSwordTransform = transform;
            if (transform.childCount > 5)
            {
                spawnSwordTransform = transform.GetChild(5).GetChild(0).GetChild(0).GetChild(0).GetChild(2);
            }
            GameObject newSword = GameObject.Instantiate(otherEvilSword, spawnSwordTransform.position, transform.rotation);
            lastThrown = Time.realtimeSinceStartup;

            Vector3 throwDirection = spawnSwordTransform.right;
            Vector3 throwTargetPosition = spawnSwordTransform.position + throwDirection * 100;
            newSword.transform.LookAt(throwTargetPosition);
        }
        */
    }
}
