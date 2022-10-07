using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quadrants : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int unlockedIndex = Random.Range(0,4);
        Transform unlockedQuadrantTransform = transform.GetChild(unlockedIndex);
        GameObject unlockedQuadrant = unlockedQuadrantTransform.gameObject;
        unlockedQuadrant.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
