using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Velocity : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<rotate> ().speed = 300;
		StartCoroutine (DieWhenReady ());
	}
	
	// Update is called once per frame
	void Update () {       

	}

	IEnumerator DieWhenReady () {
		yield return new WaitForSeconds (PowerUp.TIME);
		GetComponent<rotate> ().speed = 120;
		Destroy (gameObject.GetComponent<PowerUp_Velocity> ());
	}

}
