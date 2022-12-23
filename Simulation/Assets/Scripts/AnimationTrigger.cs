using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class AnimationTrigger : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;

    [SerializeField] private Transform pilotSeat;
    [SerializeField] private GameObject pilot;
    [SerializeField] private GameObject locomotionSystem;


    private float waitSeconds = 3.0f;
    private bool teleport = false;
    private void Update()
    {
        if (teleport)
        {
            if (waitSeconds <= 0)
            {
                pilot.transform.position = pilotSeat.position;
                pilot.transform.rotation = pilotSeat.rotation;
                //Destroy(locomotionSystem.GetComponent<DeviceBasedContinuousMoveProvider>());
                GetComponent<BoxCollider>().enabled = false;
                //Sesler düzeltilecek 

                Destroy(gameObject);
            } 
            else
                waitSeconds -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PlayerHand"))
        {
           teleport = true;
                Debug.Log("Animasyon Baþladý");
            //   myDoor.Play("DoorOpen", 0, 0.0f); gameObject.SetActive(false);
            //  myDoor.SetBool("Door",true);
            myDoor.SetTrigger("Open");
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            teleport = false;
            waitSeconds = 3.0f;
            Debug.Log("Animasyon Bitti");
            //  myDoor.Play("DoorClose", 0, 0.0f); gameObject.SetActive(false);
            //myDoor.SetBool("Door",false);
            myDoor.SetTrigger("Close");
        }

    }

}
