using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barrelScript : MonoBehaviour
{
	private float health=4;
	public Image healthBar;
  	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.name=="FriendBullet(Clone)"){
			if (health > 0)
			{
				health--;
				healthBar.fillAmount = health / 4f;
				healthBar.transform.parent.GetComponent<Canvas>().enabled = true;
			}
			if(health==0){
				transform.gameObject.tag="Untagged";
				healthBar.transform.parent.GetComponent<Canvas>().enabled=false;
				transform.Find("barrel.002").gameObject.SetActive(false);
				transform.Find("barrelParts").gameObject.SetActive(true);
				Destroy(transform.gameObject,2f);
			}
		}
	}
}
