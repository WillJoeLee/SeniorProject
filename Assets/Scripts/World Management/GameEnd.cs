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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (winGame || loseGame)
        {
            if (winGame)
            {
                winText.SetActive(true);
                winGame = false;
            }
            if (loseGame)
            {
                loseText.SetActive(true);
                loseGame = false;
            }
            StartCoroutine(WaitALilBit());
        }
    }

    IEnumerator WaitALilBit()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("SampleScene");
    }
}
