using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 1f;
    public GameObject HitParticles;

    void Awake()
    {
        Destroy(gameObject, life);
    }

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

            enemy.TakeDamage(Random.Range(0, 100));
        }
    }
}
