using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PlayerHand"))
        {
           
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

            Debug.Log("Animasyon Bitti");
            //  myDoor.Play("DoorClose", 0, 0.0f); gameObject.SetActive(false);
            //myDoor.SetBool("Door",false);
            myDoor.SetTrigger("Close");
        }

    }

}
