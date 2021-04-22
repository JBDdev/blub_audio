using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotTesting : MonoBehaviour
{
    FMODUnity.StudioEventEmitter[] emitters;
    // Start is called before the first frame update
    void Start()
    {
        emitters = transform.GetComponents<FMODUnity.StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        //Plays one shot sounds via number keys

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            emitters[0].Play();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            emitters[1].Play();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            emitters[2].Play();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            emitters[3].Play();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            emitters[4].Play();
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            emitters[5].Play();
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            emitters[6].Play();
        }


    }
}
