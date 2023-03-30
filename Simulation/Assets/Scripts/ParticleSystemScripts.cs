using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleSystemScripts : MonoBehaviour
{
   [SerializeField]
    private GameObject postSmoke;

    [SerializeField]
    private bool test;

    [SerializeField]
    private GameObject fireObject;

    // Start is called before the first frame update
    private ParticleSystem [] ps;
    void Start()
    {
        ps = GetComponentsInChildren<ParticleSystem>();
        
        
    }

    public void stopParticles()
    {
        for (int i = 0; i < ps.Length; i++)
        {
            var main = ps[i].main;
            main.loop = false;
            if (i == ps.Length - 1)
            {
                fireObject.SetActive(false);
                postSmoke.SetActive(true);

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
      
    }
    



}


