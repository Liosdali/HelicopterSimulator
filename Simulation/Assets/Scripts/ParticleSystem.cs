using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleSystem : MonoBehaviour


{


    [SerializeField]
    private bool test;

    // Start is called before the first frame update
    private ParticleSystem ps;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }




}


