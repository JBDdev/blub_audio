using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public FMODUnity.StudioEventEmitter[] emitters;
    PlayerMovement pMove;
    [SerializeField] GameObject player;
    [SerializeField] float rotModulo;
    [SerializeField] float maxFallSpeed = 500.0f;
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

        if (Input.GetKey(KeyCode.Space))
        {
            emitters[3].SetParameter("Player Size", (player.transform.localScale.x - pMove.baseDiameter) / (pMove.maxStretch - pMove.baseDiameter));
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            emitters[4].SetParameter("Player Size", (player.transform.localScale.x - pMove.baseDiameter) / (pMove.maxStretch - pMove.baseDiameter));
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

        emitters[5].SetParameter("Player Speed", Mathf.Abs(player.transform.GetComponent<Rigidbody2D>().angularVelocity) / 750f);
        emitters[6].SetParameter("Player Speed", Mathf.Abs(player.transform.GetComponent<Rigidbody2D>().angularVelocity) / 750f);
        

        rotModulo = Mathf.Abs(player.transform.rotation.z) % 90;
        //Debug.Log(rotModulo);
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
