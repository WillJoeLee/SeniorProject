using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public bool winGame = false;
    public bool loseGame = false;
    public GameObject winText;
    public GameObject loseText;
    public GameObject VRTexts;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // If all players are dead
        //GameObject.FindGameObjectsWithTag("Player");
        bool allDead = true;
        foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
          if(player.transform.GetChild(0).GetChild(0).gameObject.activeInHierarchy == true)
          {
            allDead = false;
          }
        }


        if (winGame || (loseGame && allDead))
        {
            if (winGame)
            {
                winText.SetActive(true);
                winGame = false;
                foreach(Transform T in VRTexts.transform)
                {
                  TextMesh vrTextMesh = T.gameObject.GetComponent<TextMesh>();
                  vrTextMesh.text = "Angels Win!";
                }
            }
            if (loseGame && allDead)
            {
                loseText.SetActive(true);
                loseGame = false;
                foreach(Transform T in VRTexts.transform)
                {
                  TextMesh vrTextMesh = T.gameObject.GetComponent<TextMesh>();
                  vrTextMesh.text = "Exile Wins!";
                }
            }
            StartCoroutine(WaitALilBit());
        }
    }

    IEnumerator WaitALilBit()
    {
        yield return new WaitForSeconds(15.0f);
        SceneManager.LoadScene("SampleScene");
    }
}
