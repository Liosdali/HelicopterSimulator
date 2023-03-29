using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{
   /* [SerializeField]
    private Transform startPos;

    [SerializeField]
    private Transform finPos;

    [SerializeField]
    private GameObject delivObj;
   */
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

   /* private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("InitialPosition"))
        {
            if (hook_Enabled)
            {
                Debug.Log(other.GetComponentInParent<BoxCollider>().gameObject.name);
                other.GetComponent<MeshRenderer>().enabled = false;
                other.gameObject.GetComponent<CapsuleCollider>().gameObject.SetActive(false);
                dropObject.SetActive(true);
                //hookTransform = other.gameObject.transform;

                // Needs to change 

                ArrowScript.Instance.SetTarget(dropObject.transform);
            }
        }
        else if (other.CompareTag("FinalPosition"))
        {
            if (!triggered)
            {
                triggered = true;
                hookTransform = dropPos;
                hookTransform = null;
                //hookTransform.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                //hookTransform.gameObject.GetComponent<Rigidbody>().useGravity = true;
                //dropObject.GetComponent<Rigidbody>().useGravity = true;

                //dropObject.SetActive(false);


            }
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag ==" TAG GOES HERE")
        {
            // Handling mission stuff
        }
    }*/

    

}
