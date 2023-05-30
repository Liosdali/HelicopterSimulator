using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSetScript : MonoBehaviour
{
    [SerializeField]
    GameObject headset;
    [SerializeField]
    AudioSource headsetAudioSource;
    [SerializeField]
    AudioSource helicopterAudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "headset")
        {
            headsetAudioSource.volume = 100;
            helicopterAudioSource.volume = 20;
            Debug.Log("GнRDннннннн");
            Destroy(headset);
            //other.gameObject.SetActive(false);
        } 
    }
}
