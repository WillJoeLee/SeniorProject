using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameStart : MonoBehaviour
{
    public PlayerInputManager playerInputManager;
    public GameObject ReadyTexts;
    public TextMesh StartingInTextMesh;

    private bool allReady;
    private bool countingDown;
    private float timeEndCountDown;
    private float timeNow;

    // Start is called before the first frame update
    void Start()
    {
      allReady = false;
      countingDown = false;
    }

    // Update is called once per frame
    void Update()
    {
      int playerIndex = 0;
      foreach(GameObject Player in GameObject.FindGameObjectsWithTag("Player"))
      {
        Debug.Log(Player.transform.position);
        Transform associatedReadyText = ReadyTexts.transform.GetChild(playerIndex);
        Player.transform.position = new Vector3(associatedReadyText.position.x, 1, associatedReadyText.position.z);
        playerIndex++;
      }

      for(int i = 0; i < playerInputManager.playerCount; i++)
      {
        ReadyTexts.transform.GetChild(i).gameObject.SetActive(true);
      }
      for(int i = 3; i >= playerInputManager.playerCount; i--)
      {
        ReadyTexts.transform.GetChild(i).gameObject.SetActive(false);
      }

      int numberOfPlayers = playerInputManager.playerCount;
      int numberOfReadyPlayers = GameObject.FindGameObjectsWithTag("Ready").Length;
      if((numberOfPlayers == numberOfReadyPlayers) && !countingDown)
      {
        timeEndCountDown = Time.realtimeSinceStartup + (float)6;
        countingDown = true;
      }

      if(numberOfPlayers != numberOfReadyPlayers)
      {
        countingDown = false;
      }

      if(countingDown)
      {
        float timeLeft = timeEndCountDown - Time.realtimeSinceStartup;
        StartingInTextMesh.text = "Starting in " + (int)timeLeft;

        if(timeLeft <= 0)
        {
          ReadyTexts.SetActive(false);
          StartingInTextMesh.gameObject.SetActive(false);
          playerInputManager.splitScreen = true;
          playerInputManager.enabled = false;
          playerInputManager.enabled = true;
          transform.gameObject.SetActive(false);
        }
      }
      else
      {
        StartingInTextMesh.text = "";
      }
    }
}
