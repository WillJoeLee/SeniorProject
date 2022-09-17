using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currHealth = 100f;
    public bool isDead = false;

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

    // Update is called once per frame
    void Update()
    {
        if (currHealth == 0)
        {
            isDead = true;
            Destroy(gameObject);
        }
    }

}
