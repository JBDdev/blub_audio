using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    FMODUnity.StudioEventEmitter[] emitters;
    [SerializeField] Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        emitters = transform.GetComponents<FMODUnity.StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.gameObject.SetActive(!canvas.gameObject.activeSelf);

            if (canvas.gameObject.activeSelf)
            {
                emitters[1].Play();
            }
            else
            {
                emitters[2].Play();
            }
        }
    }

    public void continueButton()
    {
        emitters[0].Play();
        canvas.gameObject.SetActive(false);
    }

    public void exitButton()
    {
        emitters[0].Play();
        Application.Quit();
    }
}
