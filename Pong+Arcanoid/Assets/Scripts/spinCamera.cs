//Aquest Script es posarà a la càmara (també podriem girar tot el mapa sense problemes, però amb la càmara és tant senzill com afegir el script i ja està)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinCamera : MonoBehaviour {
    public bool spinIsActive        = false;            //posar a true quan comenci la partida
    public float SPIN_WAIT_TIME     = 4.0f;
    public float MAX_SPIN_DURATION  = 2.0f;
    public float SPIN_SPEED         = 45.0f;

    private float nextSpinCooldown      = 0;            //temps fins a la pròxima vegada que girarà
    private float currentSpinCooldown   = 0;            //temps que es passarà fent el gir actual
    private bool spinningState = false;

    float randomDir = 1;

    void Start () {
        nextSpinCooldown    = SPIN_WAIT_TIME;
        currentSpinCooldown = MAX_SPIN_DURATION;

    }
	
	void Update () {
        if (spinIsActive)
        {
            if (spinningState)  //girant
            {
                gameObject.transform.Rotate(new Vector3(0, 0, randomDir*Time.deltaTime * SPIN_SPEED));
                currentSpinCooldown -= Time.deltaTime;

                if (currentSpinCooldown <= 0)
                {
                    currentSpinCooldown = MAX_SPIN_DURATION;
                    spinningState = false;
                }
            }
            else                //esperant el proxim gir
            {
                nextSpinCooldown -= Time.deltaTime;
                if (nextSpinCooldown <= 0)
                {
                    nextSpinCooldown = SPIN_WAIT_TIME;
                    spinningState = true;
                    randomDir = (Random.Range(-1.0f, 1.0f) > 0 ? 1 : -1);       //random que serà -1 o 1
                }
            }
        }
        //TODO: fer que els temps de duració de gir, i la espera del gir, siguin randoms? també es podria fer que a mesura que avança la partida, la velocitat augmenta o duren més, etc.
	}
}
