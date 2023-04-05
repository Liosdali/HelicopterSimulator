using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMission : Mission
{
    [SerializeField]
    private float m_fireHp;

    [SerializeField]
    public bool _isExt;

    [SerializeField]
    private float extingRate;

    [SerializeField]
    private GameObject postSmoke;

    [SerializeField]
    private ParticleSystemScripts particleSys;


    // Initializing variables;
    void Start()
    {
        _isExt = false;
        type = MissionType.Fire;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (test)
        {
            if (waterPercentage > 0f)
            {
                waterPercentage -= 100f * Time.deltaTime * flowRate;
                

            }
            particleSys.stopParticles();
        }*/
    }

    // Function to put out fire by reducing its strenght
    // Particles size or number may be lowered after getting some hits to hp
    public void reduceHp()
    {
        m_fireHp -= Time.deltaTime * extingRate; 
        if(m_fireHp < 0)
        {
            particleSys.stopParticles();
            postSmoke.SetActive(true);
            _isExt = true;
        }       
    }


    //private void OnTriggerStay(Collider other)
    //{

    //    if (other.CompareTag("InitialPosition"))
    //    {
    //        Debug.Log(other);
    //        if (hook_enabled)
    //        {
    //            if (waterPercentage<100f) { 
    //            waterPercentage += waterPercentage *Time.deltaTime * flowRate;
    //            Debug.Log(waterPercentage);
    //            }
    //            other.gameObject.GetComponent<CapsuleCollider>().gameObject.SetActive(false);

    //        }
    //    }
    //    else if (other.CompareTag("FinalPosition"))
    //    {
    //        if (!trigger)
    //        {
                
    //            trigger = true;
    //            if (waterPercentage>0) { 
    //            waterPercentage -= waterPercentage * Time.deltaTime * flowRate;
    //            }
    //            particleSys.stopParticles();


    //        }
    //    }
    //}a
}
