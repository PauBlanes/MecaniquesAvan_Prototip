//Aquest Script es posarà a la càmara (també podriem girar tot el mapa sense problemes, però així és una mica més senzill)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinCamera : MonoBehaviour {

    //posar a true quan comenci la partida
    public bool spinIsActive = false;
    public float MAX_COOLDOWN;
    public float SPIN_SPEED;

    void Start () {
		
	}
	
	void Update () {
        if (spinIsActive)
        {

        }
	}
}
