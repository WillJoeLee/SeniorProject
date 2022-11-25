using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCues : MonoBehaviour
{
    int idx = 0;
    public Transform CueTexts;

    public void setCueText (int index)
    {
        idx = index;
        foreach (Transform kid in CueTexts)
        {
            kid.gameObject.SetActive(false);
        }
        CueTexts.GetChild(idx).gameObject.SetActive(true);
        StartCoroutine(WaitALilBit());
    }

    IEnumerator WaitALilBit()
    {
        yield return new WaitForSeconds(3.0f);
        CueTexts.GetChild(idx).gameObject.SetActive(false);
    }
}
