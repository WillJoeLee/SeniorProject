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

    //This function causes damage over time if the Quadrant is Locked and there is a player in the quadrant
    /*
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemy))
        {
            float x = collision.gameObject.transform.position.x;
            float y = collision.gameObject.transform.position.y;
            float z = collision.gameObject.transform.position.z;

            Quaternion rotation = collision.gameObject.transform.rotation;

            collision.gameObject.GetComponent<Animator>().SetTrigger("IsHurt");
            Instantiate(HitParticles, new Vector3(x, y, z), rotation);

            enemy.TakeDamage(5);
            
        }
    }
    */

    // Update is called once per frame
    void Update()
    {

    }
}
