using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour
{

    [SerializeField]
    private Transform dropPos;
    private Transform hookTransform = null;
    private bool hook_Enabled = false;

    [SerializeField]
    private GameObject dropObject;

    [SerializeField]
    private GameObject fireObject;

    private bool triggered = false;

    // Update is called once per frame
    void Update()
    {
        if (hookTransform != null)
        {
            hookTransform.position = new Vector3(transform.position.x, transform.position.y -15, transform.position.z);
        }

    }

    public void HookFunction ()
    {
        hook_Enabled = true;
    }




    // Mission needs to be configured 

    // A primitive version of mission event handler 
    // Needs to be changed to suit better and become easier to add or remove missions

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Deliverable"))
        {
            if (hook_Enabled)
            {
                hookTransform = other.GetComponentInParent<BoxCollider>().gameObject.transform;
                Debug.Log(other.GetComponentInParent<BoxCollider>().gameObject.name);
                other.GetComponent<MeshRenderer>().enabled = false;
                other.gameObject.GetComponent<CapsuleCollider>().gameObject.SetActive(false);
                dropObject.SetActive(true);
                //hookTransform = other.gameObject.transform;

                // Needs to change 

                ArrowScript.Instance.SetTarget(dropObject.transform);
            }
        }
        else if (other.CompareTag("Drop"))
        {
            if (!triggered)
            {
                triggered = true;
                hookTransform = dropPos;

                hookTransform = null;
                hookTransform.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                hookTransform.gameObject.GetComponent<Rigidbody>().useGravity = true;
                dropObject.GetComponent<Rigidbody>().useGravity = true;
                dropObject.SetActive(false);
                fireObject.SetActive(false);
                
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Deliverable"))
            hook_Enabled = false;
    }

    /*
     * 
     * Testing function 
     * Works in a way that if the collided object 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Deliverable"))
        {
            Debug.Log("Hooked");
            hookTransform = collision.gameObject.transform;
        }
    }

    */



}
