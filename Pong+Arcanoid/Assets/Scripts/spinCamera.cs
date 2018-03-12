//Aquest Script es posarà a la càmara (també podriem girar tot el mapa sense problemes, però així és una mica més senzill)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinCamera : MonoBehaviour {
    //encara no he pogut fer proves perque no tinc el Unity del tot instal·lat, de fet he hagut de programar una mica "a pelo"
    
    public bool spinIsActive        = false;            //posar a true quan comenci la partida
    public float SPIN_WAIT_TIME     = 5.0f;
    public float MAX_SPIN_DURATION  = 2.0f;
    public float SPIN_SPEED         = 50.0f;

    private float nextSpinCooldown      = 0;            //temps fins a la pròxima vegada que girarà
    private float currentSpinCooldown   = 0;            //temps que es passarà fent el gir actual
    private bool spinningState = false;

    void Start () {
        nextSpinCooldown    = SPIN_WAIT_TIME;
        currentSpinCooldown = MAX_SPIN_DURATION;

    }
	
	void Update () {
        if (spinIsActive)
        {
            if (spinningState)  //girant
            {
                //float randomDir = random(); //random que sigui -1 o 1
                //gameObject.transform.Rotate(new Vector3(0, 0, randomDir*Time.deltaTime * SPIN_SPEED));
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
                }
            }
        }
        //TODO: fer que els temps de duració de gir, i la espera del gir, siguin randoms? també es podria fer que a mesura que avança la partida, la velocitat augmenta o duren més, etc.
	}
}
