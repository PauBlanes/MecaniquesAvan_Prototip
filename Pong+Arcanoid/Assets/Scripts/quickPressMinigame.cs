using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quickPressMinigame : MonoBehaviour {

    enum minigameStates
    {
        instructions,
        minigame,
        resut
    }
    private minigameStates currentState = minigameStates.instructions;

    public float INSTRUCTIONS_COOLDOWN = 3.0F;
    public float MINIGAME_DURATION = 3.0F;
    public float RESULT_COOLDOWN = 3.0F;

    private float currentCooldown = 3.0f;   //tots els cooldowns usaran aquesta variable
    public bool minigameStarted = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (currentState)
        {
            case minigameStates.instructions:
                currentCooldown -= Time.deltaTime;
                if (currentCooldown <0)
                {
                    currentState = minigameStates.minigame;

                }
                break;
            case minigameStates.minigame:

                break;
            case minigameStates.resut:

                break;
            default:
                break;
        }
    }
}
