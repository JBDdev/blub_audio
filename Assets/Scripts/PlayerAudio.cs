using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public FMODUnity.StudioEventEmitter[] emitters;
    PlayerMovement pMove;
    [SerializeField] GameObject player;
    [SerializeField] float rotModulo;
    bool playedHonk = true;
    // Start is called before the first frame update
    void Start()
    {
        emitters = transform.GetComponents<FMODUnity.StudioEventEmitter>();
        //Very hacky way of getting info from PlayerMovement behavior, should rewrite to use events later!
        pMove = player.transform.GetComponent<PlayerMovement>();
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            emitters[3].Play();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            emitters[3].Stop();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            emitters[4].Play();
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            emitters[4].Stop();
        }

        rotModulo = Mathf.Abs(player.transform.rotation.z) % 90;
        Debug.Log(rotModulo);
        if (rotModulo <= 0.25f || rotModulo > 0.95f)
        {          
            if (!playedHonk)
            {
                emitters[5].Play();
                playedHonk = true;
            }
        }
        else
        {
            emitters[5].Stop();
            playedHonk = false;
        }

    }
}
