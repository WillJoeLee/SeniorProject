using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameStart : MonoBehaviour
{
    public PlayerInputManager playerInputManager;
    public GameObject ReadyTexts;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      for(int i = 0; i < playerInputManager.playerCount; i++)
      {
        ReadyTexts.transform.GetChild(i).gameObject.SetActive(true);
      }
      for(int i = 3; i >= playerInputManager.playerCount; i--)
      {
        ReadyTexts.transform.GetChild(i).gameObject.SetActive(false);
      }
    }
}
