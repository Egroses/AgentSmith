using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{	
	public GameObject runner;
	private Vector3 vector3=new Vector3(-3,-7,9);
    private void Update() {
		transform.position=runner.transform.position-vector3;
	}
}
