using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Oyedoyin.RotaryWing;

public class HeadSetScript : MonoBehaviour
{
    [SerializeField]
    GameObject headset;
    [SerializeField]
    AudioSource headsetAudioSource;
    [SerializeField]
    AudioSource helicopterAudioSource;

    [SerializeField]
    SilantroTurboshaft m_turboShaft;


    [SerializeField]
    SilantroRotor m_turboRotor;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "headset")
        {
            headsetAudioSource.volume = 80;
            //helicopterAudioSource.volume = 20;


            m_turboShaft.ChangeSoundVolume(0.2f);
            m_turboRotor.ChangeRotorVolume(0.2f);

            Destroy(headset);
            //other.gameObject.SetActive(false);
        } 
    }
}
