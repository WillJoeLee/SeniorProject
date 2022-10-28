using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private const int IN_MAIN_MENU = 0;

    public Transform player;
    public Transform playerSpawn;

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
        
        // Set the health bar to be invisible until game start, see Update()
        healthBar.gameObject.SetActive(false);
    }

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

        healthBar.SetHealth(currHealth);

    }

    private void Respawn1()
    {
        currHealth = 1;
        healthBar.SetHealth(currHealth);
        player.GetComponent<CharacterController>().enabled = false;
        player.position = playerSpawn.position;
        player.GetComponent<CharacterController>().enabled = true;
        transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        isDead = true;
    }

    public void Respawn2()
    {
        currHealth = maxHealth;
        healthBar.SetHealth(currHealth);
        player.GetComponent<CharacterController>().enabled = false;
        player.position = playerSpawn.position;
        player.GetComponent<CharacterController>().enabled = true;
        transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        isDead = false;
    }

    //update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene().buildIndex != IN_MAIN_MENU)
        {
            // Set the health bar to be visible game started
            healthBar.gameObject.SetActive(true);

            if (currHealth == 0)
            {
                Respawn1();
            }
        }
    }
}
