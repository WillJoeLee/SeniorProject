using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AngelShieldMechanics : MonoBehaviour
{
    public GameObject angelicShield;
    public bool CanAttack = true;
    public AudioClip ShieldAttackSound;

    //collision detection
    public bool IsAttacking = false;

    public PlayerInput playerInput;
    private InputActionAsset playerInputActionAsset;

    // Update is called once per frame
    void Update()
    {

        if (angelicShield.activeSelf)
        {

            bool attackBool = playerInputActionAsset.actionMaps[0].actions[3].ReadValue<float>() == (float)1;
            if (attackBool)
            {
                if (CanAttack)
                {
                    ShieldAttack();
                }
            }
            else
            {
                var angelicShieldRenderer = angelicShield.GetComponent<Renderer>();
                
                Color customColor = new Color32(0, 0, 0, 0);
                angelicShieldRenderer.material.SetColor("_Color", customColor);
            }
        }
    }

    public void ShieldAttack()
    {
        IsAttacking = true;
        CanAttack = false;
        playerInputActionAsset.actionMaps[0].actions[6].Disable();
        playerInputActionAsset.actionMaps[0].actions[4].Disable();

        var angelicShieldRenderer = angelicShield.GetComponent<Renderer>();

        Color customColor = new Color(0.0f, 212.0f, 212.0f, 86.0f);
        angelicShieldRenderer.material.SetColor("_Color", customColor);

        //GetComponent<AudioSource>().PlayOneShot(ShieldAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    //co-routine's
    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(1.0f);
        CanAttack = true;
        playerInputActionAsset.actionMaps[0].actions[6].Enable();
        playerInputActionAsset.actionMaps[0].actions[4].Enable();
    }

    IEnumerator ResetAttackBool()
    {
        //set to length of final animation, for now default 1 sec
        yield return new WaitForSeconds(1.0f);
        IsAttacking = false;
    }
}
