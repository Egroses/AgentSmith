using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
	public void SceneChange3(){
		SceneManager.LoadScene("Level3");
	}
	public void SceneChange2()
	{
		SceneManager.LoadScene("Level2");
	}
	public void SceneChange1()
	{
		SceneManager.LoadScene("Level1");
	}

}
