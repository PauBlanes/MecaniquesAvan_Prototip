using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int redScore;
	public static int blueScore;

	public Text redScoreText;
	public Text blueScoreText;

	public Text winText;
	public Text restartText;
	public bool won;

	// Use this for initialization
	void Start () {
		winText.text = "";
		redScore = blueScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		redScoreText.text = "SCORE : " + redScore;
		blueScoreText.text = "SCORE : " + blueScore;

		//Win
		if (redScore >= 21) {
			Time.timeScale = 0;
			won = true;
			restartText.enabled = true;
			winText.text = "RED WINS!";
		}
		if (blueScore >= 21) {
			Time.timeScale = 0;
			won = true;
			restartText.enabled = true;
			winText.text = "BLUE WINS!";
		}
		if (won && Input.GetKey(KeyCode.R)) {
			Time.timeScale = 1;
			Application.LoadLevel("MiniGame");
		}
	}
}
