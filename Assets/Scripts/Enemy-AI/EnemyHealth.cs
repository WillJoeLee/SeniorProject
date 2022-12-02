using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currHealth = 100f;
    private float life = 60f;

    public void Heal(float num)
    {
        if (maxHealth < (currHealth + num))
            currHealth = maxHealth;
        else
            currHealth += num;
    }

    public void TakeDamage(float num)
    {
        if (currHealth < num)
            currHealth = 0;
        else
            currHealth -= num;
    }

    void Awake()
    {
        Destroy(gameObject, life);
    }

    //update is called once per frame
    void Update()
    {
        if (currHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
