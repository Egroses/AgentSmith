using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwatControl : MonoBehaviour
{
	Animator animator;
	EnemyTrigger enemyTrigger;
	public GameObject bullet;
	public GameObject dropBullet;
	public GameObject SwatWeapon;
	private float fireTime=0.7f;
	private float timeCount=0f;
	private GameObject bulletFirePoint;
	public float health=3;
	public float healthdiv = 3;
	public Image healthBar;
    void Start()
    {
		animator=GetComponent<Animator>();
		enemyTrigger=transform.parent.transform.Find("EnemyGetTrigger").GetComponent<EnemyTrigger>();
		bulletFirePoint=SwatWeapon.transform.Find("Bullet Reference").gameObject;
    }

    void Update()
    {
        if(enemyTrigger.getTrigger()){
			animator.SetBool("Exterminate",true);
		}
		else if(enemyTrigger.getTrigger()){
			animator.SetBool("Exterminate",false);
		}
    }

	private void weaponOnFire(){
		GameObject go=Instantiate(bullet,bulletFirePoint.transform.position,Quaternion.identity);
		go.GetComponent<bulletScript>().bulletType("Swat");
		go.GetComponent<bulletScript>().destroyObject(bulletFirePoint);

	}
	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.name=="FriendBullet(Clone)"){
			if (health > 0)
			{
				health--;
				healthBar.fillAmount = health / healthdiv;
				healthBar.transform.parent.GetComponent<Canvas>().enabled = true;
			}
			if(health==0){
				animator.SetTrigger("die");
				transform.GetComponent<Rigidbody>().isKinematic=true;
				transform.GetComponent<Rigidbody>().detectCollisions=false;
				Instantiate(dropBullet,transform.position,Quaternion.identity);
				healthBar.transform.parent.GetComponent<Canvas>().enabled=false;
				Destroy(transform.gameObject,2f);
			}
		}
	}
}
