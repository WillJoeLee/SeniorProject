using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanishedSword : MonoBehaviour
{
    public float swordSpeed = 1f;
    public float despawnAfterCollide = 5f;
    //public float despawnNoMatterCollide = 30f;

    // Start is called before the first frame update
    void Start()
    {
      //GameObject.Destroy(transform.gameObject, despawnNoMatterCollide);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
      transform.position = transform.position + transform.forward * swordSpeed;

      if(transform.position.y <= 0.5f)
      {
        swordSpeed = 0f;
        transform.GetChild(6).gameObject.SetActive(true);
        GameObject.Destroy(transform.gameObject, despawnAfterCollide);
      }
    }
}
