using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public FMODUnity.StudioEventEmitter[] emitters;
    PlayerMovement pMove;
    // Start is called before the first frame update
    void Start()
    {
        emitters = transform.GetComponents<FMODUnity.StudioEventEmitter>();
        //Very hacky way of getting info from PlayerMovement behavior, should rewrite to use events later!
        pMove = transform.parent.GetComponentsInChildren<PlayerMovement>()[0];
    }

    // Update is called once per frame
    void Update()
    {
        //Plays one shot sounds via number keys

        if (Input.GetKeyDown(KeyCode.E) && pMove.canDash)
        {
            emitters[0].Play();
        }

        if (Input.GetKeyDown(KeyCode.W) && !pMove.usedJump)
        {
            emitters[1].Play();
        }

        if (pMove.hardFall)
        {
            emitters[2].Play();
        }

        


    }
}
