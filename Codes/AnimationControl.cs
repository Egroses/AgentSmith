using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    Animator animator;
	Shoot shoot;
	public GameObject weapon1;
	public GameObject weapon2;

	private void Start() {
		animator=GetComponent<Animator>();
		shoot=GetComponent<Shoot>();
	}

    public void run(){
		animator.SetBool("push",true);
	}
    public void takePistol(){
		animator.SetBool("gunOn",true);
		shoot.WeaponOff(weapon2);
		shoot.WeaponOn(weapon1);
	}
	public void takeRevolver(){
		animator.SetBool("gunOn",true);
		shoot.WeaponOff(weapon1);
		shoot.WeaponOn(weapon2);
	}
	public void weaponFire(){
		animator.SetBool("ammo",true);
	}
	public void weaponStop(){
		animator.SetBool("ammo",false);
	}
	public void dieRunner(){
		animator.SetTrigger("die");
	}
	public void winRunner(){
		animator.SetTrigger("win");
	}
}
