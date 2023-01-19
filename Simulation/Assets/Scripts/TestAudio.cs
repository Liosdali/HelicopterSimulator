using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TestAudio : MonoBehaviour
{
    // Start is called before the first frame update

    // Primitive audio player


    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }


    private float waitSeconds = 0.5f;
    // Update is called once per frame
    void Update()
    {
        if (waitSeconds > 0)
        waitSeconds -= Time.deltaTime;
    }

    private bool playing = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerHand"))
        {
            if (audioSource != null && waitSeconds <= 0)
            {
                waitSeconds = 0.5f;
                Debug.Log("Radio Starting to Play");
                if (playing)
                    audioSource.Stop();
                else
                    audioSource.Play();
                playing = !playing;
            }
        }
    }

}
