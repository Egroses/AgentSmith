using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
	private bool rT=false;
   public void OnTriggerEnter(Collider other) {
	   if(other.gameObject.name=="MainChar"){
		   rT=true;
	   }
   }
   public bool getTrigger(){
	   return rT;
   }
}
