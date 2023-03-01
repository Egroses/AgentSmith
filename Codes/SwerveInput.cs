using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveInput : MonoBehaviour
{
    private float lastXLocation;
	private float move=0f;

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
			lastXLocation=Input.mousePosition.x;
		}
		if(Input.GetMouseButton(0)){
			move=Input.mousePosition.x-lastXLocation;
			lastXLocation=Input.mousePosition.x;
		}
		if(Input.GetMouseButtonUp(0)){
			move=0f;
		}	
    }

	[SerializeField]
	public float moveX(){
		return move;
	}
}
