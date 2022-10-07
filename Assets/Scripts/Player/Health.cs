using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Transform player;
    public Transform playerSpawn;

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

    void Respawn()
    {
        currHealth = maxHealth;
        player.GetComponent<CharacterController>().enabled = false;
        player.position = playerSpawn.position;
        player.GetComponent<CharacterController>().enabled = true;
        isDead = false;
    }

    //update is called once per frame
    void Update()
    {
        if (currHealth == 0)
        {
            isDead = true;
            Respawn();
        }
    }
}
