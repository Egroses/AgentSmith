using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    private GameObject bulletFirePoint;
	private Vector3 pos=new Vector3(0,0,0);
	private int a = 0;
    void Update()
    {
		if (transform.gameObject != null) {		
			transform.position+=pos;
			if(Vector3.Distance(bulletFirePoint.transform.position,transform.position)>50f){
				Destroy(transform.gameObject);
			}
		}
	}
	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Enemy")
			Destroy(transform.gameObject);
	}
	public void destroyObject(GameObject go){
		bulletFirePoint=go;
	}
	public void bulletType(string obje){
		if(obje=="Char")
			pos=new Vector3(0,0,0.3f);
		
		if(obje=="Swat")
			pos=new Vector3(0,0,-0.3f);
	}
	
}
