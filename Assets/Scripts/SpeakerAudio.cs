using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerAudio : MonoBehaviour
{
    [SerializeField] Transform player;
    FMODUnity.StudioEventEmitter e;

    // Start is called before the first frame update
    void Start()
    {
        e = transform.GetComponent<FMODUnity.StudioEventEmitter>();    
    }

    // Update is called once per frame
    void Update()
    {
        float distanceSq = Mathf.Pow(transform.position.x - player.position.x, 2.0f) + Mathf.Pow(transform.position.y - player.position.y, 2.0f);
        e.SetParameter("Distance", distanceSq / 200f);
    }
}
