using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
	public GameObject Sword;
	public bool CanAttack = true;
	public AudioClip SwordAttackSound;

	//collision detection
	public bool IsAttacking = false;

	//update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
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
		Sword.GetComponent<Animator>().SetTrigger("Attack");
		//GetComponent<AudioSource>().PlayOneShot(SwordAttackSound);
		StartCoroutine(ResetAttackCooldown());
	}

	//co-routine's
	IEnumerator ResetAttackCooldown()
	{
		StartCoroutine(ResetAttackBool());
		yield return new WaitForSeconds(1.0f);
		CanAttack = true;
	}

	IEnumerator ResetAttackBool()
	{
		//set to length of final animation, for now default 1 sec
		yield return new WaitForSeconds(1.0f);
		IsAttacking = false;
	}
}
