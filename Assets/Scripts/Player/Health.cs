using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private const int IN_MAIN_MENU = 0;

    public Transform player;
    public Transform playerSpawn;
    public GameObject body;
    public GameObject weaponHolder;
    public GameObject angelicShield;
    public GameObject QueueManager;
    //public Runes runes;

    public float maxHealth = 100f;
    public float currHealth = 100f;
    public bool isDead = false;

    // Health Bar additions
    // Any questions reach out to: Michel
    public HealthBar healthBar;

    void Start()
    {
        currHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        //set the health bar to be invisible until game start, see Update()
        //healthBar.gameObject.SetActive(false);

        healthBar.SetHealth(currHealth);
    }

    public void Heal(float num)
    {
        if (maxHealth < (currHealth + num))
            currHealth = maxHealth;
        else
            currHealth += num;
        healthBar.SetHealth(currHealth);
    }

    public void TakeDamage(float num)
    {
        if (currHealth < num) 
            currHealth = 0;
        else
            currHealth -= num;

        healthBar.SetHealth(currHealth);
    }

    private void Respawn1()
    {
        currHealth = 1;
        healthBar.SetHealth(currHealth);
        player.GetComponent<CharacterController>().enabled = false;
        player.position = playerSpawn.position;
        player.GetComponent<CharacterController>().enabled = true;
        weaponHolder.SetActive(false);
        angelicShield.SetActive(true);
        body.SetActive(false);
        //runes.deactivateAllRunes();
        QueueManager.GetComponent<GameQueues>().setQueueText(4);
        isDead = true;
    }

    public void Respawn2()
    {
        currHealth = maxHealth;
        healthBar.SetHealth(currHealth);
        player.GetComponent<CharacterController>().enabled = false;
        player.position = playerSpawn.position;
        player.GetComponent<CharacterController>().enabled = true;
        weaponHolder.SetActive(true);
        body.SetActive(true);
        //runes.activateAllRunes();
        QueueManager.GetComponent<GameQueues>().setQueueText(5);
        isDead = false;
    }

    void Update()
    {
        if (currHealth == 0)
        {
            Respawn1();
        }
    }

    //update is called once per frame
    //void Update()
    //{

    //    if (SceneManager.GetActiveScene().buildIndex != IN_MAIN_MENU)
    //    {
    //        // Set the health bar to be visible game started
    //        healthBar.gameObject.SetActive(true);

    //        if (currHealth == 0)
    //        {
    //            Respawn1();
    //        }
    //    }
    //}
}
