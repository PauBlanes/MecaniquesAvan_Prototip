using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour {

	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2(0,5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D coll) {
		/*Vector2 normal = coll.transform.parent.position - coll.transform.parent.position;
		Debug.DrawLine (coll.transform.parent.position, coll.transform.parent.position, Color.red);
		rb.velocity *= -1;*/
	}
}
