using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSetScript : MonoBehaviour
{
    [SerializeField]
    GameObject headset;

    AudioSource headsetAudioSource;
    AudioSource helicopterAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "headset")
        {

            headsetAudioSource.volume = 100;
            helicopterAudioSource.volume = 20;
            Destroy(headset);

        } 
    }
}
