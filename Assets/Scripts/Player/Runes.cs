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

    const string DEBUG_E_1 = "DEBUG-Rune_E";
    const string DEBUG_H_2 = "DEBUG-Rune_H";
    const string DEBUG_R_3 = "DEBUG-Rune_R";
    const string DEBUG_X_4 = "DEBUG-Rune_X";
    const string DEBUG_DEACTIVATE = "DEBUG-Deactivate_All_Rune";

    private bool active_rt = false;
    private bool E_active = false;
    private bool H_active = false;
    private bool R_active = false;
    private bool X_active = false;

    public Transform player;
    public RunesTracker runeTracker;

    private bool isOveride = false;

    public void setRuneEactive()
    {
        E_active = true;
    }

    public void setRuneHactive()
    {
        H_active = true;
    }

    public void setRuneRactive()
    {
        R_active = true;
    }

    public void setRuneXactive()
    {
        X_active = true;
    }

    public void setRuneEdeactive()
    {
        E_active = false;
    }

    public void setRuneHdeactive()
    {
        H_active = false;
    }

    public void setRuneRdeactive()
    {
        R_active = false;
    }

    public void setRuneXdeactive()
    {
        X_active = false;
    }

    public void deactivateAllRunes()
    {
        setRuneEdeactive();
        setRuneHdeactive();
        setRuneRdeactive();
        setRuneXdeactive();
        active_rt = false;
        isOveride = true;
        runeTracker.gameObject.SetActive(false);
    }

    public void reactivateAllRunes()
    {
        runeTracker.ReactivateRunes();
        active_rt = true;
        isOveride = false;
        runeTracker.gameObject.SetActive(true);
    }



    // Start is called before the first frame update
    void Start()
    {
        // Set the RuneTacker to be invisible until game start, see Update()
        runeTracker.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != IN_MAIN_MENU && !isOveride)
        {
            // Set the RuneTacker to be visible game started
            runeTracker.gameObject.SetActive(true);
            active_rt = true;
        }

        if (active_rt)
        {
            // should light up the corresponding rune when picked up
            if (!E_active)
            {
                runeTracker.SetDeactiveRune(RUNE_E);
            }
            else
            {
                runeTracker.SetActiveRune(RUNE_E);
            }

            if (!H_active)
            {
                runeTracker.SetDeactiveRune(RUNE_H);
            }
            else
            {
                runeTracker.SetActiveRune(RUNE_H);
            }

            if (!R_active)
            {
                runeTracker.SetDeactiveRune(RUNE_R);
            }
            else
            {
                runeTracker.SetActiveRune(RUNE_R);
            }

            if (!X_active)
            {
                runeTracker.SetDeactiveRune(RUNE_X);
            }
            else
            {
                runeTracker.SetActiveRune(RUNE_X);
            }
        }

    }
}
