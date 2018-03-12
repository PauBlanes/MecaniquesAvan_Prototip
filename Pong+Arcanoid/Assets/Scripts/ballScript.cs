using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour {

	Rigidbody2D rb;
	float startVel;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2(0,5);
		startVel = rb.velocity.magnitude;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void LateUpdate () {
		if (rb.velocity.magnitude < startVel) {
			rb.velocity = rb.velocity.normalized * startVel;
		}
	}
	void OnTriggerEnter2D(Collider2D coll) {
		/*Vector2 normal = coll.transform.parent.position - coll.transform.parent.position;
		Debug.DrawLine (coll.transform.parent.position, coll.transform.parent.position, Color.red);
		rb.velocity *= -1;*/
	}
}
