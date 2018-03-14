using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Player : MonoBehaviour {


    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Invertir")
        {
         
        }

        if (coll.gameObject.tag == "PowerUp_Velocity")
        {
            //Codi 
            gameObject.AddComponent<PowerUp_Velocity>();
        }

        if (coll.gameObject.tag == "ExtraBall")
        {

        }

        if (coll.gameObject.tag == "ExtraPaddle")
        {

        }

    }


}
