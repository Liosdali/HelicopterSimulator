using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{

    // To do
    // - update required stuff after event completed
    // - Create Two different childs 
    // - Fire Mission - Mission End
    public Transform missionTransform;

    // Start is called before the first frame update
    void Start()
    {
        missionTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MissionEventStart()
    {

    }

    public void MissionEventEnd()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag ==" TAG GOES HERE")
        {
            // Handling mission stuff
        }
    }



}
