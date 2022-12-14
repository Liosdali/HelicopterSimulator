using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour
{


    private Transform hookTransform = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hookTransform != null)
        {
            hookTransform.position = new Vector3(transform.position.x, transform.position.y -15, transform.position.z);
        }



    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Deliverable"))
        {
            Debug.Log("Hooked");
            hookTransform = collision.gameObject.transform;
        }
    }
}
