using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMission : Mission
{
    [SerializeField]
    private float waterPercentage;

    [SerializeField]
    private bool test;

    [SerializeField]
    private float flowRate;

    [SerializeField]
    private bool hook_enabled;

    private bool trigger = false;

    [SerializeField]
    private ParticleSystemScripts particleSys;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (test)
        {
            if (waterPercentage > 0f)
            {
                waterPercentage -= 100f * Time.deltaTime * flowRate;
                

            }
            particleSys.stopParticles();
        }
    }

    //public void HookFunction()
    //{
    //    hook_enabled = true;
    //}

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("InitialPosition"))
        {
            Debug.Log(other);
            if (hook_enabled)
            {
                if (waterPercentage<100f) { 
                waterPercentage += waterPercentage *Time.deltaTime * flowRate;
                Debug.Log(waterPercentage);
                }
                other.gameObject.GetComponent<CapsuleCollider>().gameObject.SetActive(false);

            }
        }
        else if (other.CompareTag("FinalPosition"))
        {
            if (!trigger)
            {
                
                trigger = true;
                if (waterPercentage>0) { 
                waterPercentage -= waterPercentage * Time.deltaTime * flowRate;
                }
                particleSys.stopParticles();


            }
        }
    }
}
