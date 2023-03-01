using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class runner : MonoBehaviour
{
	AnimationControl animationControl;
	BulletStack bulletStack;
	private SwerveInput swerveInput;
	public float speed=15f;
	private float runnerPlace;
	public float maxSwerveLimit=15f;
	public float runPower=0.1f;
	private bool startControl=false;
	private bool endGame=false;
	private Rigidbody aga;
	private Vector3 vector3;
	public float health=10;
	public Image healthBar;
	public float healTime=5f;
	
    void Start()
    {
		animationControl=GetComponent<AnimationControl>();
		bulletStack=GameObject.Find("BulletReferancePoint").GetComponent<BulletStack>();
        swerveInput=GetComponent<SwerveInput>();
		aga=GetComponent<Rigidbody>();
	}

    void Update()
    {	
		if(startControl&&!endGame){
			runnerPlace=0.03f*swerveInput.moveX();
			runnerPlace=Mathf.Clamp(runnerPlace,-maxSwerveLimit,maxSwerveLimit);
			vector3=new Vector3(runnerPlace,0,runPower);
		}
		
	}
	private void FixedUpdate() {
		if(startControl&&!endGame){
			if((aga.position+vector3).x<-4.2)
				vector3.x=0;
			else if((aga.position+vector3).x>4)
				vector3.x=0;
			aga.MovePosition(aga.position+vector3);
			animationControl.run();
			healTime-=Time.deltaTime;
			if(healTime<0f&&health<10){
				health++;
				healthBar.fillAmount=health/10f;
			}
			else if(health==10){
				healthBar.transform.parent.GetComponent<Canvas>().enabled=false;
			}
		}
	}
	public void isStartGame(){
		startControl=true;
		GameObject.Find("Canvas").transform.Find("gameScreen").transform.Find("TaptoStart").gameObject.SetActive(false);
	}
	public bool isEndGame(){
		return endGame;
	}
	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag=="Door"){
			if(other.gameObject.name=="GunGatePistol"){
				other.gameObject.transform.parent.Find("GunGateRevolver").gameObject.GetComponent<BoxCollider>().enabled=false;
				animationControl.takePistol();
			}
			else if(other.gameObject.name=="GunGateRevolver"){
				other.gameObject.transform.parent.Find("GunGatePistol").gameObject.GetComponent<BoxCollider>().enabled = false;
				animationControl.takeRevolver();
			}
		}
		if(other.gameObject.tag=="BulletCollect"){
			bulletStack.takedBullet(1);
			animationControl.weaponFire();
			other.gameObject.SetActive(false);
		}	
		if(other.gameObject.name=="EnemyBullet(Clone)"){
			if (health > 0)
			{
				health--;
				healthBar.fillAmount = health / 10f;
				healthBar.transform.parent.GetComponent<Canvas>().enabled = true;
				healTime = 5f;
			}
			if(health==0){
				animationControl.dieRunner();
				transform.GetComponent<Rigidbody>().isKinematic=true;
				transform.GetComponent<Rigidbody>().detectCollisions=false;
				endGame=true;
				healthBar.transform.parent.GetComponent<Canvas>().enabled=false;
				GameObject.Find("Canvas").transform.Find("gameScreen").transform.Find("Fail").gameObject.SetActive(true);
			}
		}
		if(other.gameObject.name=="winLine"){
			endGame=true;
			animationControl.winRunner();
			healthBar.transform.parent.GetComponent<Canvas>().enabled=false;	
			GameObject.Find("Canvas").transform.Find("gameScreen").transform.Find("Success").gameObject.SetActive(true);
		}
	}
	private void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag=="Enemy"||other.gameObject.tag=="Obstacle"){
			animationControl.dieRunner();
			endGame=true;
			healthBar.transform.parent.GetComponent<Canvas>().enabled = false;
			GameObject.Find("Canvas").transform.Find("gameScreen").transform.Find("Fail").gameObject.SetActive(true);
		}
	}
	
}
