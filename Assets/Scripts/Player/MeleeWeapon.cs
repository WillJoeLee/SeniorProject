using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
	public GameObject Sword;
	public bool CanAttack = true;
	public float AttackCooldown = 1.0f;
	public AudioClip SwordAttackSound;

	private const int LEFT_CLICK = 0;
	private const string ATTACK = "Attack";
	private const float ONE_SECOND = 1.0f;

	//collision detection
	public bool IsAttacking = false;

	void Update()
	{
		if (Input.GetMouseButtonDown(LEFT_CLICK))
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
		Animator anim = Sword.GetComponent<Animator>();
		anim.SetTrigger(ATTACK);
		//AudioSource ac = GetComponent<AudioSource>();
		//ac.PlayOneShot(SwordAttackSound);
		StartCoroutine(ResetAttackCooldown());
	}

	//co-routine's
	IEnumerator ResetAttackCooldown()
	{
		StartCoroutine(ResetAttackBool());
		yield return new WaitForSeconds(AttackCooldown);
		CanAttack = true;
	}

	IEnumerator ResetAttackBool()
	{
		//set to length of final animation, for now default 1 sec
		yield return new WaitForSeconds(ONE_SECOND);
		IsAttacking = false;
	}

}
