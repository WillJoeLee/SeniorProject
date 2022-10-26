using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Runes : MonoBehaviour
{
    private const int IN_MAIN_MENU = 0;

    const string RUNE_E = "rune-e";
    const string RUNE_H = "rune-h";
    const string RUNE_R = "rune-r";
    const string RUNE_X = "rune-x";

    private bool active = false;

    public Transform player;
    public RunesTracker runeTracker;

    // Start is called before the first frame update
    void Start()
    {
        // Set the RuneTacker to be invisible until game start, see Update()
        runeTracker.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != IN_MAIN_MENU)
        {
            // Set the RuneTacker to be visible game started
            runeTracker.gameObject.SetActive(true);
            active = true;
        }

        // The following is broken debugging code,
        // should light up the corresponding rune when pressing one of the number key.
        // Not part of the final product just a debugging tool to test functiuonallity.

        //if(Input.GetKey(KeyCode.1))
        //{
        //    runeTracker.SetActiveRune(runeTracker.RUNE_E);
        //}

        //if (Input.GetKeyUp(KeyCode.2))
        //{
        //    runeTracker.SetActiveRune(runeTracker.RUNE_H);
        //}

        //if (Input.GetKeyUp(KeyCode.3))
        //{
        //    runeTracker.SetActiveRune(runeTracker.RUNE_R);
        //}

        //if (Input.GetKeyUp(KeyCode.4))
        //{
        //    runeTracker.SetActiveRune(runeTracker.RUNE_X);
        //}

        //if (Input.GetKeyUp(KeyCode.5))
        //{
        //    if (active)
        //    {
        //        runeTracker.DeactivateRunes();
        //    } else
        //    {
        //        runeTracker.ReactivateRunes();
        //    }
        //    
        //}

    }
}
