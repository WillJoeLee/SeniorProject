using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeleeWeapon : MonoBehaviour
{
	public GameObject Sword;
	public bool CanAttack = true;
	public AudioClip SwordAttackSound;

	//collision detection
	public bool IsAttacking = false;

	public PlayerInput playerInput;
	private InputActionAsset playerInputActionAsset;

	void Start()
	{
		playerInputActionAsset = playerInput.actions;
	}

	//update is called once per frame
	void Update()
	{
		bool attackBool = playerInputActionAsset.actionMaps[0].actions[3].ReadValue<float>() == (float)1;
		if (attackBool)
		{
			if (CanAttack)
			{
				SwordAttack();
			}
		}
	}

	public void SwordAttack()
	{
		IsAttacking = true;
		CanAttack = false;
		playerInputActionAsset.actionMaps[0].actions[6].Disable();
		playerInputActionAsset.actionMaps[0].actions[4].Disable();
		Sword.GetComponent<Animator>().SetTrigger("Attack");
		GetComponent<AudioSource>().PlayOneShot(SwordAttackSound);
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
