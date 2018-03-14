using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUp : MonoBehaviour {

    public static float TIME = 5.0f;

    Rigidbody2D rb;
    float startVel = 3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2((float)Random.Range (2, 10) / 10, (float)Random.Range (2, 10) / 10);
    }

    void LateUpdate()
    {
		if (rb.velocity.magnitude < startVel) {
			rb.velocity = rb.velocity.normalized * startVel;
		}
    }

    private void Update()
    {
        Physics2D.IgnoreLayerCollision(8, 9);

        Destroy(gameObject, TIME);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);

        }
    }



}
