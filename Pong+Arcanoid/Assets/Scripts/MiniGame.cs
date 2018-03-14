using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MiniGame : MonoBehaviour {
	private enum Direcction {UP,DOWN,LEFT,RIGHT}; 
	public Text timeText;
	private float timeCount = 0;
	private Direcction dir;
	private bool isBLUE;
	// Use this for initialization
	void Start () {
		timeText.text = "0";
		dir = (Direcction)Random.Range(0, 4);
	}
	
	// Update is called once per frame
	void Update () {
		timeCount+=Time.deltaTime;
		timeText.text=timeCount.ToString("f0");

		if(timeCount>=3){	
			timeText.text=dir.ToString();
			if (Input.GetKeyDown(KeyCode.UpArrow)&&dir==Direcction.UP){
				isBLUE=true;
				Application.LoadLevel("Main");
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow)&&dir==Direcction.DOWN){
				isBLUE=true;
				Application.LoadLevel("Main");
			}
			else if (Input.GetKeyDown(KeyCode.LeftArrow)&&dir==Direcction.LEFT){
				isBLUE=true;
				Application.LoadLevel("Main");
			}
			else if (Input.GetKeyDown(KeyCode.RightArrow)&&dir==Direcction.RIGHT){
				isBLUE=true;
				Application.LoadLevel("Main");
			}
			else if (Input.GetKeyDown(KeyCode.W)&&dir==Direcction.UP){
				isBLUE=false;
				Application.LoadLevel("Main");
			}
			else if (Input.GetKeyDown(KeyCode.D)&&dir==Direcction.DOWN){
				isBLUE=false;
				Application.LoadLevel("Main");
			}
			else if (Input.GetKeyDown(KeyCode.A)&&dir==Direcction.LEFT){
				isBLUE=false;
				Application.LoadLevel("Main");
			}
			else if (Input.GetKeyDown(KeyCode.D)&&dir==Direcction.RIGHT){
				isBLUE=false;
				Application.LoadLevel("Main");
			}
			else if(Input.anyKeyDown){
				dir = (Direcction)Random.Range(0, 4);
			}
		}
	}
}
