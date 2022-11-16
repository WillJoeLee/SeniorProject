using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AngelShieldMechanics : MonoBehaviour
{
    public GameObject angelicShield;
    public AudioClip ShieldAttackSound;

    //collision detection
    public bool IsAttacking = false;

    public PlayerInput playerInput;
    public Health health;
    private InputActionAsset playerInputActionAsset;

    void Start()
    {
        playerInputActionAsset = playerInput.actions;
    }

    void Update()
    {

        if (health.isDead)
        {
            bool attackBool = playerInputActionAsset.actionMaps[0].actions[3].ReadValue<float>() == (float)1;
            if (attackBool)
            {
                angelicShield.SetActive(true);
                IsAttacking = true;
            }
            else
            {
                angelicShield.SetActive(false);
                IsAttacking = false;
            }
        }
        
    }
    
}
