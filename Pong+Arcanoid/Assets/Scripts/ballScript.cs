using System.Collections;
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
		rb.velocity = new Vector2(0,1);
		currentVel = startVel;

	}
	
	// Update is called once per frame
	void Update () {
		//mentre tenim la bola agafada la velocitat va aumentant i la pala es fa petita
		if (catched && currentVel < 10) {
			currentVel += 3 * Time.deltaTime;
			paddle.localScale -= new Vector3 (0.12f * Time.deltaTime, 0, 0);
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


}
