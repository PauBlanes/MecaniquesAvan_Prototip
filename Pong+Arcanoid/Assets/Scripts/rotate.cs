using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {
    public float speed = 120;
    public GameObject center;
    public bool down = false;
    float min, max;
	// Use this for initialization
	void Start () {
        if (down)
        {
            
        }
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

        }
        else
        {
            if (Input.GetKey(KeyCode.A) && (center.transform.rotation.eulerAngles.z+ Time.deltaTime * speed) < 165)
            {
                center.transform.Rotate(new Vector3(0, 0, Time.deltaTime * speed));
            }
            if (Input.GetKey(KeyCode.D) && (center.transform.rotation.eulerAngles.z - Time.deltaTime * speed) > 15)
            {
                print(center.transform.rotation.eulerAngles.z);
                center.transform.Rotate(new Vector3(0, 0, -Time.deltaTime * speed));
            }
        }
    }
}
