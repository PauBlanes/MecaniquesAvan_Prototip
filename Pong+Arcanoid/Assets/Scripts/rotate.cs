using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {
    public float speed = 120;
    public GameObject center;
    public bool down = false;
    float min, max;

	//Per fer el catch de la bola
	bool canCatchBall;
	ballScript bS;
	float currentLength; //per si modifiquem el tamany en algun altre lloc


	// Use this for initialization
	void Start () {
		currentLength = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (down)
        {
            if (Input.GetKey(KeyCode.LeftArrow) && (center.transform.rotation.eulerAngles.z - Time.deltaTime * speed) > 195)
            {
                center.transform.Rotate(new Vector3(0,0,-Time.deltaTime* speed));
            }
            if (Input.GetKey(KeyCode.RightArrow) && (center.transform.rotation.eulerAngles.z + Time.deltaTime * speed) < 345)
            {
                center.transform.Rotate(new Vector3(0, 0, Time.deltaTime * speed));
            }

			//Catch/Release the ball
			if (Input.GetKey (KeyCode.DownArrow) && canCatchBall) {
				bS.StartCatch (transform);
				canCatchBall = false;
			}
			if (Input.GetKeyUp (KeyCode.DownArrow) && bS.GetVelocity() == 0)
				bS.Release ();

        }
        else
        {
            if (Input.GetKey(KeyCode.A) && (center.transform.rotation.eulerAngles.z+ Time.deltaTime * speed) < 165)
            {
                center.transform.Rotate(new Vector3(0, 0, Time.deltaTime * speed));
            }
            if (Input.GetKey(KeyCode.D) && (center.transform.rotation.eulerAngles.z - Time.deltaTime * speed) > 15)
            {
               // print(center.transform.rotation.eulerAngles.z);
                center.transform.Rotate(new Vector3(0, 0, -Time.deltaTime * speed));
            }

			//Catch/Release the ball
			if (Input.GetKey (KeyCode.S) && canCatchBall) {
				bS.StartCatch (transform);
				canCatchBall = false;
			}
			if (Input.GetKeyUp (KeyCode.S) && bS.GetVelocity() == 0)
					bS.Release ();			
        }

		//si no tenim la bola i la pala es petita ha de anar tornant al tamany normal
		if (transform.localScale.x < currentLength && bS.GetVelocity() != 0) {
			transform.localScale += new Vector3 (0.05f * Time.deltaTime, 0, 0);
		}
    }

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.transform.tag == "ball") {
			canCatchBall = true;
			if (bS == null)
				bS = coll.gameObject.GetComponent<ballScript> ();
		}

	}
	void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.transform.tag == "ball") {
			canCatchBall = false;
		}

	}


}
