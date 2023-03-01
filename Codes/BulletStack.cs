using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStack : MonoBehaviour
{
	public GameObject runner;
	public GameObject bullet;
	private bool bel=true;
	private GameObject go;
	private Vector3 refPos;
	private Vector3 bulletPos;
	private Stack<GameObject> bulletStackList=new Stack<GameObject>();
    void Start()
    { 	
		refPos=new Vector3(-0,-1.8f,0.36f);
    }

    void Update()
    {
		if(!runner.GetComponent<runner>().isEndGame()){
			transform.position=runner.transform.position-refPos;
			bulletPos=runner.transform.position-refPos;
		}
		else{
			bulletStackList=new Stack<GameObject>();
		}
		if(runner.GetComponent<runner>().isEndGame()){
			transform.gameObject.SetActive(false);
		}
    }
	public void takedBullet(int i){
		while(i>0){
			if(bulletStackList.Count!=0){
				bulletPos=bulletStackList.Peek().transform.position+new Vector3(0,0.3f,0);
			}
			go=Instantiate(bullet,bulletPos,Quaternion.identity);
			go.transform.SetParent(transform);
			bulletStackList.Push(go);			
			i--;
		}
	}
	public void bulletOut(){
		if(bulletStackList.Count>0){
			Destroy(bulletStackList.Peek());
			bulletStackList.Pop();
		}
	}
	public int getBulletCount(){
		return bulletStackList.Count;
	}
}
