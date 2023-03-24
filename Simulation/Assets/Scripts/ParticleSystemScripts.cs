using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleSystemScripts : MonoBehaviour


{


    [SerializeField]
    private bool test;

    // Start is called before the first frame update
    private ParticleSystem [] ps;
    void Start()
    {
        ps = GetComponentsInChildren<ParticleSystem>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (test)
        {
            var main = ps.main;
            main.loop = false;

        }

        
    }




}


