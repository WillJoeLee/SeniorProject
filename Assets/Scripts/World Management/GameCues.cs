using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCues : MonoBehaviour
{
    int idx = 0;
    GameObject gmr;

    public void setCueText (int index, GameObject gamer)
    {
        idx = index;
        gmr = gamer;
        foreach (Transform kid in gmr.transform.GetChild(0).GetChild(1))
        {
            kid.gameObject.SetActive(false);
        }
        gmr.transform.GetChild(0).GetChild(1).GetChild(idx).gameObject.SetActive(true);

        StartCoroutine(WaitALilBit());
    }

    IEnumerator WaitALilBit()
    {
        yield return new WaitForSeconds(3.0f);
        gmr.transform.GetChild(0).GetChild(1).GetChild(idx).gameObject.SetActive(false);
    }
}
