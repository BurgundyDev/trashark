using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerScript : MonoBehaviour
{
public GameObject[] pauseObjects;
public GameObject[] stoppedUI;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		hidePaused();
	}

	// Update is called once per frame
	void Update () {

		//uses the p button to pause and unpause the game
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			} else if (Time.timeScale == 0){
				Debug.Log ("high");
				Time.timeScale = 1;
				hidePaused();
			}
		}
	}

	//controls the pausing of the scene
	public void pauseControl(){
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			} else if (Time.timeScale == 0){
				Time.timeScale = 1;
				hidePaused();
			}
	}

	//shows objects with ShowOnPause tag
	public void showPaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(true);
		}
		foreach(GameObject u in stoppedUI)
		{
			u.SetActive(false);
		}
	}

	//hides objects with ShowOnPause tag
	public void hidePaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(false);
		}
		foreach(GameObject u in stoppedUI)
		{
			u.SetActive(true);
		}
	}
}
