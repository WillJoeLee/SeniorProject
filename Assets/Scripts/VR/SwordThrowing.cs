using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SwordThrowing : MonoBehaviour
{
    public bool isRightHand;
    public GameObject banishedSword;
    private Transform indexFingerTransform;
    public float throwDelay;

    private bool triggerIsDown;
    private bool canThrowSword;

    private float lastThrown;

    // Start is called before the first frame update
    void Start()
    {
      triggerIsDown = false;
      canThrowSword = true;
    }

    // Update is called once per frame
    void Update()
    {
      canThrowSword = (Time.realtimeSinceStartup - lastThrown) > throwDelay;

      if(isRightHand)
      {
        triggerIsDown = SteamVR_Input.GetState("GrabPinch", SteamVR_Input_Sources.RightHand);
      }
      else
      {
        triggerIsDown = SteamVR_Input.GetState("GrabPinch", SteamVR_Input_Sources.LeftHand);
      }

      if(triggerIsDown && canThrowSword)
      {
        Transform spawnSwordTransform = transform;
        if(transform.childCount > 5)
        {
          spawnSwordTransform = transform.GetChild(5).GetChild(0).GetChild(0).GetChild(0).GetChild(2);
        }
        GameObject newSword = GameObject.Instantiate(banishedSword, spawnSwordTransform.position, transform.rotation);
        lastThrown = Time.realtimeSinceStartup;

        Vector3 throwDirection = spawnSwordTransform.right;
        Vector3 throwTargetPosition = spawnSwordTransform.position + throwDirection * 100;
        newSword.transform.LookAt(throwTargetPosition);
      }
    }
}
