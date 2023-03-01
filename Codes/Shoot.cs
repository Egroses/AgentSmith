using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	private AnimationControl animationControl;
	BulletStack bulletStack;
	public GameObject bullet;
	private GameObject bulletFirePoint;
	private int bulletCount;
	private float fireTime=0.73f;
	private float timeCount=0f;
	private bool weaponTrue=false;
	private void Start() {
		bulletStack=GameObject.Find("BulletReferancePoint").GetComponent<BulletStack>();
		animationControl=GetComponent<AnimationControl>();
	}
	private void Update() {
		
	}
    public void WeaponOn(GameObject weapon){
		weapon.SetActive(true);
		bulletFirePoint=weapon.transform.Find("Bullet Reference").gameObject;
		bulletStack.takedBullet(Random.Range(4,10));
		weaponTrue=true;
		animationControl.weaponFire();
	}

	public void WeaponOff(GameObject weapon){
		weapon.SetActive(false);
		weaponTrue=false;
	}

	private void weaponOnFire(){
		if(bulletStack.getBulletCount()>0){
			bulletStack.bulletOut();
			GameObject go=Instantiate(bullet,bulletFirePoint.transform.position,Quaternion.identity);
			go.GetComponent<bulletScript>().bulletType("Char");
			go.GetComponent<bulletScript>().destroyObject(bulletFirePoint);
		}
		if(bulletStack.getBulletCount()<=0){
			animationControl.weaponStop();
		}
	}
}



