﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour {
	
	Rigidbody2D rb;
	public float startVel;
	private float currentVel;

	bool catched;
	Transform paddle;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		if (MiniGame.isBLUE)
			StartCoroutine (SpawnBall (new Vector2 (0, 1)));
		else
			StartCoroutine (SpawnBall (new Vector2 (0, -1)));
		currentVel = startVel;
	}
	
	// Update is called once per frame
	void Update () {
		//mentre tenim la bola agafada la velocitat va aumentant i la pala es fa petita
		if (catched && currentVel < 12) {
			currentVel += 4 * Time.deltaTime;
			paddle.localScale -= new Vector3 (0.12f * Time.deltaTime, 0, 0);
			if (paddle.localScale.x < 0.05)
				paddle.localScale = new Vector3 (Mathf.Clamp (paddle.localScale.x, 0.05f, 10f), paddle.localScale.y, paddle.localScale.z);
		}
	}
	void LateUpdate () {
		if (rb.velocity.magnitude < currentVel) {
			rb.velocity = rb.velocity.normalized * currentVel;
		}
		if (catched) //pq no roti amb el pare
			transform.localRotation = Quaternion.Euler (0, 0, 0);
	}

	public void StartCatch (Transform fakeParent) {
		rb.velocity = new Vector2 (0, 0);
		transform.parent = fakeParent.parent;
		paddle = fakeParent;
		catched = true;
	}
	public void Release () {
		transform.parent = null;

		rb.velocity = new Vector3(0,0) - transform.position;
		rb.velocity = rb.velocity.normalized * startVel;

		catched = false;
	}
	public float GetVelocity () {
		return rb.velocity.magnitude;
	}
	public void ResetVel() {
		if (currentVel > startVel)
			currentVel = startVel;
		
		rb.velocity = rb.velocity.normalized * currentVel;
	}
	IEnumerator SpawnBall (Vector2 newVel) {
		transform.position = Vector3.zero;
		rb.velocity = Vector2.zero;
		yield return new WaitForSeconds (1);
		rb.velocity = newVel;
		ResetVel ();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.tag == "blueWall") {
			ResetVel ();
			ScoreManager.redScore++;
			Destroy (collision.gameObject);
		}
		if (collision.transform.tag == "blueSphere") {			
			ScoreManager.redScore+=5;

			StartCoroutine (SpawnBall (new Vector2 (0, 1)));
		}
		if (collision.transform.tag == "redWall") {
			ResetVel ();
			ScoreManager.blueScore++;
			Destroy (collision.gameObject);
		}
		if (collision.transform.tag == "redSphere") {			
			ScoreManager.blueScore+=5;
			StartCoroutine (SpawnBall (new Vector2 (0, -1)));
		}

	}


}
