using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SwordThrowing : MonoBehaviour
{
    public bool is_right_hand;

    private bool trigger_is_down;

    // Start is called before the first frame update
    void Start()
    {
      trigger_is_down = false;
    }

    // Update is called once per frame
    void Update()
    {
      if(is_right_hand)
      {
        trigger_is_down = SteamVR_Input.GetState("GrabPinch", SteamVR_Input_Sources.RightHand);
      }
      else
      {
        trigger_is_down = SteamVR_Input.GetState("GrabPinch", SteamVR_Input_Sources.LeftHand);
      }

      Debug.Log(trigger_is_down);
    }
}
