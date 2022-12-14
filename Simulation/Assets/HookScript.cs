using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour
{


    private Transform hookTransform = null;
    private bool hook_Enabled = false;

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

    public void HookFunction ()
    {
        Debug.Log(hook_Enabled);
        hook_Enabled = true;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Deliverable"))
        {
            if (hook_Enabled)
            {
                hookTransform = other.GetComponentInParent<BoxCollider>().gameObject.transform;
                Debug.Log(other.GetComponentInParent<BoxCollider>().gameObject.name);
                other.gameObject.GetComponent<CapsuleCollider>().gameObject.SetActive(false);
                //hookTransform = other.gameObject.transform;
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Deliverable"))
            hook_Enabled = false;
    }

    /*
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
