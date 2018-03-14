using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Grow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.transform.localScale += new Vector3 (0.15f, 0f, 0f);
		StartCoroutine (DieWhenReady ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator DieWhenReady () {
		yield return new WaitForSeconds (PowerUp.TIME);
		gameObject.transform.localScale -= new Vector3 (0.15f, 0f, 0f);
		Destroy (gameObject.GetComponent<PowerUp_Velocity> ());
	}
}
