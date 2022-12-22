using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
   
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PlayerHand"))
        {
            Debug.Log("Animasyon Baþlamalý");
            
                //myDoor.Play("DoorOpen", 0, 0.0f); gameObject.SetActive(false);
                myDoor.SetTrigger("DoorOpen");
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerHand")) 
        { 

                //myDoor.Play("DoorOpen", 0, 0.0f); gameObject.SetActive(true);
                myDoor.SetTrigger("DoorClose");
        }
    }

}
