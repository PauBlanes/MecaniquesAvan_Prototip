using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_System : MonoBehaviour {

    public GameObject[] powerUps;
    private float timer = 3.0f;

	void Start ()
    {
		
	}

	void Update () {
        Timer_Time();
    }

    void SpawnPowerUp()
    {
        Vector2 randomPosition = new Vector2(Random.Range(-2, 2), Random.Range(-2, 2));
        //Vector2 randomForce = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
		int index = Random.Range(0, powerUps.Length);
		GameObject power = (GameObject)Instantiate(powerUps[index], randomPosition, powerUps[index].transform.rotation);
        //power.GetComponent<Rigidbody2D>().AddForce(randomForce, ForceMode2D.Force);        
    }

    private void Timer_Time()
    {
        if(timer < 0)
        {
            SpawnPowerUp();
			timer = Random.Range(5, 10);
        } else
        {
            timer -= Time.deltaTime;
        }
    }


}
